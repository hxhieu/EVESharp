using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Common.Constants;
using Common.Logging;
using Common.Network;
using Common.Packets;
using Node.Database;
using Node.Inventory;
using Node.Inventory.Items;
using Node.Inventory.Items.Types;
using Node.Inventory.Notifications;
using Node.Inventory.SystemEntities;
using PythonTypes;
using PythonTypes.Types.Exceptions;
using PythonTypes.Types.Network;
using PythonTypes.Types.Primitives;
using SimpleInjector;

namespace Node.Network
{
    public class ClusterConnection
    {
        private Channel Log { get; }
#if DEBUG
        private Channel CallLog { get; }
        private Channel ResultLog { get; }
#endif
        public EVEClientSocket Socket { get; }
        private NodeContainer Container { get; }
        private SystemManager SystemManager { get; }
        private ItemManager ItemManager { get; }
        private ServiceManager ServiceManager { get; }
        private ClientManager ClientManager { get; }
        private BoundServiceManager BoundServiceManager { get; }
        private Container DependencyInjector { get; }
        private AccountDB AccountDB { get; }
        private CharacterManager CharacterManager { get; }

        public ClusterConnection(NodeContainer container, SystemManager systemManager, ServiceManager serviceManager,
            ClientManager clientManager, BoundServiceManager boundServiceManager, ItemManager itemManager,
            Logger logger, Container dependencyInjector, AccountDB accountDB, CharacterManager characterManager)
        {
            this.Log = logger.CreateLogChannel("ClusterConnection");
#if DEBUG
            this.CallLog = logger.CreateLogChannel("CallDebug", true);
            this.ResultLog = logger.CreateLogChannel("ResultDebug", true);
#endif
            this.SystemManager = systemManager;
            this.ServiceManager = serviceManager;
            this.ClientManager = clientManager;
            this.BoundServiceManager = boundServiceManager;
            this.DependencyInjector = dependencyInjector;
            this.ItemManager = itemManager;
            this.Container = container;
            this.AccountDB = accountDB;
            this.CharacterManager = characterManager;
            this.Socket = new EVEClientSocket(this.Log);
            this.Socket.SetReceiveCallback(ReceiveLowLevelVersionExchangeCallback);
            this.Socket.SetExceptionHandler(HandleException);
        }

        private void HandleException(Exception ex)
        {
            Log.Error("Exception detected: ");

            do
            {
                Log.Error(ex.Message);
                Log.Error(ex.StackTrace);
            } while ((ex = ex.InnerException) != null);
        }

        private void ReceiveLowLevelVersionExchangeCallback(PyDataType ar)
        {
            try
            {
                LowLevelVersionExchange exchange = CheckLowLevelVersionExchange(ar);

                // reply with the node LowLevelVersionExchange
                LowLevelVersionExchange reply = new LowLevelVersionExchange();

                reply.codename = Common.Constants.Game.codename;
                reply.birthday = Common.Constants.Game.birthday;
                reply.build = Common.Constants.Game.build;
                reply.machoVersion = Common.Constants.Game.machoVersion;
                reply.version = Common.Constants.Game.version;
                reply.region = Common.Constants.Game.region;
                reply.isNode = true;
                reply.nodeIdentifier = "Node";

                this.Socket.Send(reply);

                // set the new handler
                this.Socket.SetReceiveCallback(ReceiveNodeInitialState);
            }
            catch (Exception e)
            {
                Log.Error($"Exception caught on LowLevelVersionExchange: {e.Message}");
                throw;
            }
        }

        private void ReceiveNodeInitialState(PyDataType ar)
        {
            if (ar is PyObjectData == false)
                throw new Exception($"Expected PyObjectData for machoNet.nodeInfo but got {ar.GetType()}");

            PyObjectData info = ar as PyObjectData;

            if (info.Name != "machoNet.nodeInfo")
                throw new Exception($"Expected PyObjectData of type machoNet.nodeInfo but got {info.Name}");

            // Update our local info
            NodeInfo nodeinfo = info;

            this.Container.NodeID = nodeinfo.nodeID;

            Log.Debug("Found machoNet.nodeInfo, our new node id is " + nodeinfo.nodeID.ToString("X4"));

            // load the specified solar systems
            this.SystemManager.LoadSolarSystems(nodeinfo.solarSystems.GetEnumerable<PyInteger>());

            // finally set the new packet handler
            this.Socket.SetReceiveCallback(ReceiveNormalPacketCallback);
        }

        private void HandleCallReq(PyPacket packet, Client client)
        {
            PyTuple callInfo = ((packet.Payload[0] as PyTuple)[1] as PySubStream).Stream as PyTuple;
            
            string call = callInfo[1] as PyString;
            PyTuple args = callInfo[2] as PyTuple;
            PyDictionary sub = callInfo[3] as PyDictionary;
            PyDataType callResult = null;
            PyAddressClient source = packet.Source as PyAddressClient;
            string destinationService = null;
            CallInformation callInformation;
            
            if (packet.Destination is PyAddressAny destAny)
            {
                destinationService = destAny.Service;
            }
            else if (packet.Destination is PyAddressNode destNode)
            {
                destinationService = destNode.Service;

                if (destNode.NodeID != Container.NodeID)
                {
                    Log.Fatal(
                        "Received a call request for a node that is not us, did the ClusterController get confused or something?!"
                    );
                    return;
                }
            }
            
            callInformation = new CallInformation
            {
                Client = client,
                CallID = source.CallID,
                NamedPayload = sub,
                PacketType = packet.Type,
                Service = destinationService,
                From = packet.Source,
                To = packet.Destination
            };

            try
            {
                if (destinationService == null)
                {
                    if (callInfo[0] is PyString == false)
                    {
                        Log.Fatal("Expected bound call with bound string, but got something different");
                        return;
                    }

                    string boundString = callInfo[0] as PyString;

                    // parse the bound string to get back proper node and bound ids
                    Match regexMatch = Regex.Match(boundString, "N=([0-9]+):([0-9]+)");

                    if (regexMatch.Groups.Count != 3)
                    {
                        Log.Fatal($"Cannot find nodeID and boundID in the boundString {boundString}");
                        return;
                    }

                    int nodeID = int.Parse(regexMatch.Groups[1].Value);
                    int boundID = int.Parse(regexMatch.Groups[2].Value);

                    if (nodeID != this.Container.NodeID)
                    {
                        Log.Fatal("Got bound service call for a different node");
                        // TODO: MIGHT BE A GOOD IDEA TO RELAY THIS CALL TO THE CORRECT NODE
                        // TODO: INSIDE THE NETWORK, AT LEAST THAT'S WHAT CCP IS DOING BASED
                        // TODO: ON THE CLIENT'S CODE... NEEDS MORE INVESTIGATION
                        return;
                    }

#if DEBUG
                    CallLog.Trace("Payload");
                    CallLog.Trace(PrettyPrinter.FromDataType(args));
                    CallLog.Trace("Named payload");
                    CallLog.Trace(PrettyPrinter.FromDataType(sub));
#endif

                    callResult = this.BoundServiceManager.ServiceCall(
                        boundID, call, args, callInformation
                    );

#if DEBUG
                    ResultLog.Trace("Result");
                    ResultLog.Trace(PrettyPrinter.FromDataType(callResult));
#endif
                }
                else
                {
                    Log.Trace($"Calling {destinationService}::{call}");

#if DEBUG
                    CallLog.Trace("Payload");
                    CallLog.Trace(PrettyPrinter.FromDataType(args));
                    CallLog.Trace("Named payload");
                    CallLog.Trace(PrettyPrinter.FromDataType(sub));
#endif

                    callResult = this.ServiceManager.ServiceCall(
                        destinationService, call, args, callInformation
                    );

#if DEBUG
                    ResultLog.Trace("Result");
                    ResultLog.Trace(PrettyPrinter.FromDataType(callResult));
#endif
                }

                this.SendCallResult(callInformation, callResult);
            }
            catch (PyException e)
            {
                this.SendException(callInformation, e);
            }
            catch (ProvisionalResponse provisional)
            {
                this.SendProvisionalResponse(callInformation, provisional);
            }
        }

        private void HandleSessionChangeNotification(PyPacket packet, Client client)
        {
            Log.Debug($"Updating session for client {packet.UserID}");

            // ensure the client is registered in the node and store his session
            if (this.ClientManager.Contains(packet.UserID) == false)
                this.ClientManager.Add(packet.UserID, this.DependencyInjector.GetInstance<Client>());

            this.ClientManager.Get(packet.UserID).UpdateSession(packet);
        }

        private void HandlePingReq(PyPacket packet, Client client)
        {
            // alter package to include the times the data
            PyTuple handleMessage = new PyTuple(3);
            PyAddressClient source = packet.Source as PyAddressClient;

            // this time should come from the stream packetizer or the socket itself
            // but there's no way we're adding time tracking for all the goddamned packets
            // so this should be sufficient
            handleMessage[0] = DateTime.UtcNow.ToFileTime();
            handleMessage[1] = DateTime.UtcNow.ToFileTime();
            handleMessage[2] = "server::handle_message";
            
            PyTuple turnaround = new PyTuple(3);

            turnaround[0] = DateTime.UtcNow.ToFileTime();
            turnaround[1] = DateTime.UtcNow.ToFileTime();
            turnaround[2] = "server::turnaround";
                
            (packet.Payload[0] as PyList)?.Add(handleMessage);
            (packet.Payload[0] as PyList)?.Add(turnaround);

            // change to a response
            packet.Type = PyPacket.PacketType.PING_RSP;
                
            // switch source and destination
            packet.Source = packet.Destination;
            packet.Destination = source;
                
            // queue the packet back
            this.Socket.Send(packet);
        }

        private void HandleCallRes(PyPacket packet, Client client)
        {
            // ensure the response is directed to us
            if (packet.Destination is PyAddressNode == false)
            {
                Log.Error("Received a call response not directed to us");
                return;
            }

            PyAddressNode dest = packet.Destination as PyAddressNode;

            if (dest.NodeID != Container.NodeID)
            {
                Log.Error($"Received a call response for node {dest.NodeID} but we are {Container.NodeID}");
                return;
            }
                
            // handle call response
            if (packet.Payload.Count != 1)
            {
                Log.Error("Received a call response without proper response data");
                return;
            }

            PyDataType first = packet.Payload[0];

            if (first is PySubStream == false)
            {
                Log.Error("Received a call response without proper response data");
                return;
            }
                
            PySubStream subStream = packet.Payload[0] as PySubStream;
                
            this.ServiceManager.ReceivedRemoteCallAnswer(dest.CallID, subStream.Stream);
        }

        private void HandleOnSolarSystemLoaded(PyTuple data)
        {
            if (data.Count != 1)
            {
                Log.Error("Received OnSolarSystemLoad notification with the wrong format");
                return;
            }

            PyDataType first = data[0];

            if (first is PyInteger == false)
            {
                Log.Error("Received OnSolarSystemLoad notification with the wrong format");
                return;
            }

            PyInteger solarSystemID = first as PyInteger;

            // mark as loaded
            this.SystemManager.LoadSolarSystem(solarSystemID);
        }

        private void HandleOnClientDisconnected(PyTuple data)
        {
            if (data.Count != 1)
            {
                Log.Error("Received OnClientDisconnected notification with the wrong format");
                return;
            }

            PyDataType first = data[0];

            if (first is PyInteger == false)
            {
                Log.Error("Received OnClientDisconnected notification with the wrong format");
                return;
            }

            PyInteger clientID = first as PyInteger;
            
            // remove the client from the session list and free it's data
            if (this.ClientManager.Contains(clientID) == false)
            {
                Log.Error($"Received OnClientDisconnected notification for an unknown client {clientID}");
                return;
            }

            // get the client, search for it's common items and meta inventories and free them
            Client client = this.ClientManager.Get(clientID);

            // clear bound services for this character
            this.BoundServiceManager.OnClientDisconnected(client);
            
            // ensure the client is removed from other places where it shouldn't be
            client.OnClientDisconnected();

            // finally remove the client from the manager
            this.ClientManager.Remove(clientID);
        }

        private void HandleOnItemUpdate(PyTuple data)
        {
            if (data.Count != 2)
            {
                Log.Error("Received OnItemUpdate notification with the wrong format");
                return;
            }

            PyDataType first = data[0];

            if (first is PyInteger == false)
            {
                Log.Error("Received OnItemUpdate notification with the wrong format");
                return;
            }

            PyDataType second = data[1];

            if (second is PyDictionary == false)
            {
                Log.Error("Received OnItemUpdate notification with the wrong format");
                return;
            }

            PyInteger itemID = first as PyInteger;
            PyDictionary changes = second as PyDictionary;
            ItemEntity item = this.ItemManager.LoadItem(itemID, out bool loadRequired);
            
            // if the item was just loaded there's extra things to take into account
            // as the item might not even need a notification to the character it belongs to
            if (loadRequired == true)
            {
                // trust that the notification got to the correct node
                // load the item and check the owner, if it's logged in and the locationID is loaded by us
                // that means the item should be kept here
                if (this.ItemManager.TryGetItem(item.LocationID, out ItemEntity location) == false || this.CharacterManager.IsCharacterConnected(item.OwnerID) == false)
                {
                    // this item should not be loaded, so unload and return
                    this.ItemManager.UnloadItem(item);
                    return;
                }

                bool locationBelongsToUs = true;

                switch (location)
                {
                    case Station _:
                        locationBelongsToUs = this.SystemManager.StationBelongsToUs(location.ID);
                        break;
                    case SolarSystem _:
                        locationBelongsToUs = this.SystemManager.SolarSystemBelongsToUs(location.ID);
                        break;
                }

                if (locationBelongsToUs == false)
                {
                    this.ItemManager.UnloadItem(item);
                    return;
                }
            }

            OnItemChange itemChange = new OnItemChange(item);
            
            // update item and build change notification
            if (changes.TryGetValue("locationID", out PyDataType newLocation) == true && newLocation is PyInteger newLocationID)
            {
                itemChange.AddChange(ItemChange.LocationID, item.LocationID);
                item.LocationID = newLocationID;
            }
            
            if (changes.TryGetValue ("quantity", out PyDataType newQuantity) == true && newQuantity is PyInteger newQuantityInt)
            {
                itemChange.AddChange(ItemChange.Quantity, item.Quantity);
                item.Quantity = newQuantityInt;
            }
            
            if (changes.TryGetValue("ownerID", out PyDataType newOwner) == true && newOwner is PyInteger newOwnerID)
            {
                itemChange.AddChange(ItemChange.OwnerID, item.OwnerID);
                item.OwnerID = newOwnerID;
            }
            
            // TODO: IDEALLY THIS WOULD BE ENQUEUED SO ALL OF THEM ARE SENT AT THE SAME TIME
            // TODO: BUT FOR NOW THIS SHOULD SUFFICE
            // send the notification
            this.SendNotification("OnMultiEvent", "charid", (int) item.OwnerID,
                new PyTuple(1) {[0] = new PyList(1) {[0] = itemChange}});

            if (item.LocationID == this.ItemManager.LocationRecycler.ID)
                // the item is removed off the database if the new location is the recycler
                item.Destroy();
            else
                // save the item if the new location is not removal
                item.Persist();
        }

        private void HandleOnBalanceUpdate(PyTuple data)
        {
            if (data.Count != 2)
            {
                Log.Error("Received OnItemUpdate notification with the wrong format");
                return;
            }

            PyDataType first = data[0];

            if (first is PyInteger == false)
            {
                Log.Error("Received OnItemUpdate notification with the wrong format");
                return;
            }

            PyDataType second = data[1];

            if (second is PyDecimal == false)
            {
                Log.Error("Received OnItemUpdate notification with the wrong format");
                return;
            }

            PyInteger characterID = first as PyInteger;
            PyDecimal newBalance = second as PyDecimal;
            
            if (this.ItemManager.TryGetItem(characterID, out Character character) == false)
            {
                Log.Warning("Received a wallet update for a character that does not belong to us...");
                return;
            }

            character.Balance = newBalance;
            character.Persist();
            
            PyTuple notification = new PyTuple(new PyDataType[]
            {
                "cash", characterID, newBalance
            });
            
            this.SendNotification("OnAccountChange", "charid", (int) characterID, notification);
        }

        private void HandleBroadcastNotification(PyPacket packet)
        {
            // this packet is an internal one
            if (packet.Payload.Count != 2)
            {
                Log.Error("Received ClusterController notification with the wrong format");
                return;
            }

            PyDataType first = packet.Payload[0];
            PyDataType second = packet.Payload[1];

            if (first is PyString == false)
            {
                Log.Error("Received ClusterController notification with the wrong format");
                return;
            }

            if (second is PyTuple == false)
            {
                Log.Error("Received ClusterController notification with the wrong format");
                return;
            }

            PyString notification = first as PyString;
            PyTuple arguments = second as PyTuple;

            Log.Debug($"Received a notification from ClusterController of type {notification.Value}");
            
            switch (notification)
            {
                case "OnSolarSystemLoad":
                    this.HandleOnSolarSystemLoaded(arguments);
                    break;
                case "OnClientDisconnected":
                    this.HandleOnClientDisconnected(arguments);
                    break;
                case "OnItemUpdate":
                    this.HandleOnItemUpdate(arguments);
                    break;
                case "OnBalanceUpdate":
                    this.HandleOnBalanceUpdate(arguments);
                    break;
                default:
                    Log.Fatal("Received ClusterController notification with the wrong format");
                    break;
            }
        }

        private void HandleNotification(PyPacket packet, Client client)
        {
            if (packet.Source is PyAddressAny)
            {
                this.HandleBroadcastNotification(packet);
                return;
            }
            
            PyTuple callInfo = ((packet.Payload[0] as PyTuple)[1] as PySubStream).Stream as PyTuple;

            PyList objectIDs = callInfo[0] as PyList;
            string call = callInfo[1] as PyString;

            if (call != "ClientHasReleasedTheseObjects")
            {
                Log.Error($"Received notification from client with unknown method {call}");
                return;
            }
            
            // search for the given objects in the bound service
            // and sure they're freed
            foreach (PyTuple objectID in objectIDs.GetEnumerable<PyTuple>())
            {
                if (objectID[0] is PyString == false)
                {
                    Log.Fatal("Expected bound call with bound string, but got something different");
                    return;
                }

                string boundString = objectID[0] as PyString;

                // parse the bound string to get back proper node and bound ids
                Match regexMatch = Regex.Match(boundString, "N=([0-9]+):([0-9]+)");

                if (regexMatch.Groups.Count != 3)
                {
                    Log.Fatal($"Cannot find nodeID and boundID in the boundString {boundString}");
                    return;
                }

                int nodeID = int.Parse(regexMatch.Groups[1].Value);
                int boundID = int.Parse(regexMatch.Groups[2].Value);

                if (nodeID != this.Container.NodeID)
                {
                    Log.Fatal("Got a ClientHasReleasedTheseObjects call for an object ID that doesn't belong to us");
                    // TODO: MIGHT BE A GOOD IDEA TO RELAY THIS CALL TO THE CORRECT NODE
                    // TODO: INSIDE THE NETWORK, AT LEAST THAT'S WHAT CCP IS DOING BASED
                    // TODO: ON THE CLIENT'S CODE... NEEDS MORE INVESTIGATION
                    return;
                }
                
                this.BoundServiceManager.FreeBoundService(boundID);
            }
        }
        
        private void ReceiveNormalPacketCallback(PyDataType ar)
        {
            PyPacket packet = ar;
            Client client = null;
            
            if (this.ClientManager.Contains(packet.UserID))
                client = this.ClientManager.Get(packet.UserID);

            switch (packet.Type)
            {
                case PyPacket.PacketType.CALL_REQ:
                    this.HandleCallReq(packet, client);
                    break;
                case PyPacket.PacketType.SESSIONCHANGENOTIFICATION:
                    this.HandleSessionChangeNotification(packet, client);
                    break;
                case PyPacket.PacketType.PING_REQ:
                    this.HandlePingReq(packet, client);
                    break;
                case PyPacket.PacketType.CALL_RSP:
                    this.HandleCallRes(packet, client);
                    break;
                case PyPacket.PacketType.NOTIFICATION:
                    this.HandleNotification(packet, client);
                    break;
            }
            
            // send any notification that might be pending
            client?.SendPendingNotifications();
        }

        private static LowLevelVersionExchange CheckLowLevelVersionExchange(PyDataType exchange)
        {
            LowLevelVersionExchange data = exchange;

            if (data.birthday != Common.Constants.Game.birthday)
                throw new Exception("Wrong birthday in LowLevelVersionExchange");

            if (data.build != Common.Constants.Game.build)
                throw new Exception("Wrong build in LowLevelVersionExchange");

            if (data.codename != Common.Constants.Game.codename + "@" + Common.Constants.Game.region)
                throw new Exception("Wrong codename in LowLevelVersionExchange");

            if (data.machoVersion != Common.Constants.Game.machoVersion)
                throw new Exception("Wrong machoVersion in LowLevelVersionExchange");

            if (data.version != Common.Constants.Game.version)
                throw new Exception("Wrong version in LowLevelVersionExchange");

            if (data.isNode == true)
            {
                if (data.nodeIdentifier != "Node")
                    throw new Exception("Wrong node string in LowLevelVersionExchange");
            }
            
            return data;
        }

        public void SendNotification(string notificationType, string idType, PyList idsOfInterest, Client client, PyDataType data)
        {
            PyTuple dataContainer = new PyTuple(new PyDataType []
                {
                    1, data
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    0, dataContainer
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    0, new PySubStream(dataContainer)
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    dataContainer, null
                }
            );
            
            PyPacket packet = new PyPacket(PyPacket.PacketType.NOTIFICATION);

            packet.Destination = new PyAddressBroadcast(idsOfInterest, idType, notificationType);
            packet.Source = new PyAddressNode(this.Container.NodeID);

            packet.UserID = client.AccountID;
            packet.Payload = dataContainer;

            this.Socket.Send(packet);
        }

        public void SendNotification(string notificationType, string idType, int id, Client client, PyDataType data)
        {
            PyTuple dataContainer = new PyTuple(new PyDataType []
                {
                    1, data
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    0, dataContainer
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    0, new PySubStream(dataContainer)
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    dataContainer, null
                }
            );
            
            PyPacket packet = new PyPacket(PyPacket.PacketType.NOTIFICATION);

            packet.Destination = new PyAddressBroadcast((PyList) new PyDataType[] { id }, idType, notificationType);
            packet.Source = new PyAddressNode(this.Container.NodeID);

            packet.UserID = client.AccountID;
            packet.Payload = dataContainer;

            this.Socket.Send(packet);
        }

        public void SendNotification(string notificationType, string idType, int id, PyDataType data)
        {
            PyTuple dataContainer = new PyTuple(new PyDataType []
                {
                    1, data
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    0, dataContainer
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    0, new PySubStream(dataContainer)
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    dataContainer, null
                }
            );
            
            PyPacket packet = new PyPacket(PyPacket.PacketType.NOTIFICATION);

            packet.Destination = new PyAddressBroadcast((PyList) new PyDataType[] { id }, idType, notificationType);
            packet.Source = new PyAddressNode(this.Container.NodeID);

            // set the userID to -1, this will indicate the cluster controller to fill it in
            packet.UserID = -1;
            packet.Payload = dataContainer;

            this.Socket.Send(packet);
        }
        
        public void SendNotification(string notificationType, string idType, PyList ids, PyDataType data)
        {
            PyTuple dataContainer = new PyTuple(new PyDataType []
                {
                    1, data
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    0, dataContainer
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    0, new PySubStream(dataContainer)
                }
            );

            dataContainer = new PyTuple(new PyDataType[]
                {
                    dataContainer, null
                }
            );
            
            PyPacket packet = new PyPacket(PyPacket.PacketType.NOTIFICATION);

            packet.Destination = new PyAddressBroadcast(ids, idType, notificationType);
            packet.Source = new PyAddressNode(this.Container.NodeID);

            // set the userID to -1, this will indicate the cluster controller to fill it in
            packet.UserID = -1;
            packet.Payload = dataContainer;

            this.Socket.Send(packet);
        }
        
        /// <summary>
        /// Sends a notification from this node to the specified node
        /// </summary>
        /// <param name="nodeID">The nodeID to notify</param>
        /// <param name="type">The type of notification</param>
        /// <param name="data">The notification's data</param>
        public void SendNodeNotification(long nodeID, string type, PyTuple data)
        {
            PyPacket notification = new PyPacket(PyPacket.PacketType.NOTIFICATION);
            
            notification.Source = new PyAddressAny(0);
            notification.Destination = new PyAddressBroadcast(new PyList(1) {[0] = nodeID}, "nodeid");
            notification.Payload = new PyTuple(2) {[0] = type, [1] = data };
            notification.OutOfBounds = new PyDictionary();
            notification.UserID = -1;
            
            this.Socket.Send(notification);
        }

        public void SendProvisionalResponse(CallInformation answerTo, ProvisionalResponse response)
        {
            PyPacket result = new PyPacket(PyPacket.PacketType.CALL_RSP);
            
            // ensure destination has clientID in it
            PyAddressClient source = answerTo.From as PyAddressClient;

            source.ClientID = answerTo.Client.AccountID;
            // switch source and dest
            result.Source = answerTo.To;
            result.Destination = source;

            result.UserID = source.ClientID;
            result.Payload = new PyTuple(0);
            result.OutOfBounds = new PyDictionary
            {
                ["provisional"] = new PyTuple(3)
                {
                    [0] = response.Timeout, // macho timeout in seconds
                    [1] = response.EventID,
                    [2] = response.Arguments
                }
            };

            this.Socket.Send(result);
        }
        
        public void SendException(CallInformation answerTo, PyDataType content)
        {
            // build a new packet with the correct information
            PyPacket result = new PyPacket(PyPacket.PacketType.ERRORRESPONSE);
            
            // ensure destination has clientID in it
            PyAddressClient source = answerTo.From as PyAddressClient;

            source.ClientID = answerTo.Client.AccountID;
            // switch source and dest
            result.Source = answerTo.To;
            result.Destination = source;

            result.UserID = source.ClientID;
            result.Payload = new PyTuple(new PyDataType[]
            {
                (int) answerTo.PacketType, (int) MachoErrorType.WrappedException, new PyTuple (new PyDataType[] { new PySubStream(content) }), 
            });

            this.Socket.Send(result);
        }

        public void SendCallResult(CallInformation answerTo, PyDataType content)
        {
            PyPacket result = new PyPacket(PyPacket.PacketType.CALL_RSP);
            
            // ensure destination has clientID in it
            PyAddressClient source = answerTo.From as PyAddressClient;

            source.ClientID = answerTo.Client.AccountID;
            // switch source and dest
            result.Source = answerTo.To;
            result.Destination = source;

            result.UserID = source.ClientID;
            result.Payload = new PyTuple(new PyDataType[] {new PySubStream(content)});

            this.Socket.Send(result);
        }

        private void NodeSendServiceCall(int nodeID, string service, string call, PyTuple args, PyDictionary namedPayload,
            Action<RemoteCall, PyDataType> callback, Action<RemoteCall> timeoutCallback, object extraInfo = null, int timeoutSeconds = 0)
        {
            // node's do not have notion of nodes so just let the cluster controller know
            int callID = this.ServiceManager.ExpectRemoteServiceResult(callback, nodeID, extraInfo, timeoutCallback, timeoutSeconds);
        }

        private void ClientSendServiceCall(int clientID, string service, string call, PyTuple args, PyDictionary namedPayload,
            Action<RemoteCall, PyDataType> callback, Action<RemoteCall> timeoutCallback, object extraInfo = null, int timeoutSeconds = 0)
        {
            if (this.ClientManager.Contains(clientID) == false)
                throw new InvalidDataException("Cannot send a service call to a userID that is not registered");

            Client destination = this.ClientManager.Get(clientID);
            
            // queue the call in the service manager and get the callID
            int callID = this.ServiceManager.ExpectRemoteServiceResult(callback, destination, extraInfo, timeoutCallback, timeoutSeconds);
            
            // prepare the request packet
            PyPacket packet = new PyPacket(PyPacket.PacketType.CALL_REQ);

            packet.UserID = clientID;
            packet.Destination = new PyAddressClient(clientID, null, service);
            packet.Source = new PyAddressNode(this.Container.NodeID, callID);
            packet.OutOfBounds = new PyDictionary();
            packet.OutOfBounds["role"] = (int) Roles.ROLE_SERVICE | (int) Roles.ROLE_REMOTESERVICE;
            packet.Payload = new PyTuple(2)
            {
                [0] = new PyTuple (2)
                {
                    [0] = 0,
                    [1] = new PySubStream(new PyTuple(4)
                    {
                        [0] = 1,
                        [1] = call,
                        [2] = args,
                        [3] = namedPayload
                    })
                },
                [1] = null
            };
            
            // everything is ready, send the packet to the client
            this.Socket.Send(packet);
        }

        public void SendServiceCall(Client client, string service, string call, PyTuple args, PyDictionary namedPayload,
            Action<RemoteCall, PyDataType> callback, Action<RemoteCall> timeoutCallback = null, object extraInfo = null, int timeoutSeconds = 0)
        {
            this.ClientSendServiceCall(client.AccountID, service, call, args, namedPayload, callback, timeoutCallback, extraInfo, timeoutSeconds);
        }

        public void SendServiceCall(int characterID, string service, string call, PyTuple args, PyDictionary namedPayload,
            Action<RemoteCall, PyDataType> callback, Action<RemoteCall> timeoutCallback = null, object extraInfo = null, int timeoutSeconds = 0)
        {
            this.ClientSendServiceCall(
                this.AccountDB.GetAccountIDFromCharacterID(characterID),
                service, call, args, namedPayload, callback, timeoutCallback, extraInfo, timeoutSeconds
            );
        }

        public void SendServiceCall(Character character, string service, string call, PyTuple args, PyDictionary namedPayload,
            Action<RemoteCall, PyDataType> callback, Action<RemoteCall> timeoutCallback = null, object extraInfo = null, int timeoutSeconds = 0)
        {
            this.SendServiceCall(character.ID, service, call, args, namedPayload, callback,timeoutCallback, extraInfo, timeoutSeconds);
        }
    }
}