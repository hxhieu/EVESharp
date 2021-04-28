using System;
using System.Collections.Generic;
using Common.Database;
using MySql.Data.MySqlClient;
using Node.Inventory.Items;
using Node.StaticData.Inventory;
using PythonTypes.Types.Collections;
using PythonTypes.Types.Database;
using PythonTypes.Types.Primitives;

namespace Node.Database
{
    public class MessagesDB : DatabaseAccessor
    {
	    public Rowset GetMailHeaders(int channelID)
        {
            return Database.PrepareRowsetQuery(
	            "SELECT channelID, messageID, senderID, subject, created, `read` FROM eveMail WHERE channelID = @channelID",
	            new Dictionary<string, object>()
	            {
		            {"@channelID", channelID}
	            }
	        );
        }

	    public PyTuple GetMessageDetails(int channelID, int messageID)
        {
	        // TODO: SIMPLIFY TABLE STRUCTURE, ATTACHMENTS ARE NOT SUPPORTED
	        MySqlConnection connection = null;
	        MySqlDataReader reader = Database.PrepareQuery(ref connection,
		        "SELECT channelID, messageID, senderID, subject, body, mimeTypeID, mimeType, `binary`, created FROM eveMail LEFT JOIN eveMailMimeType USING(mimeTypeID) WHERE messageID = @messageID AND channelID = @channelID",
		        new Dictionary<string, object>()
		        {
			        {"@messageID", messageID},
			        {"@channelID", channelID}
		        }
	        );

	        using (connection)
	        using (reader)
	        {
		        if (reader.Read() == false)
			        return new PyTuple(0);

		        Row mimeTypeRow = new Row(
			        new PyList<PyString>(3)
			        {
				        [0] = "mimeTypeID",
				        [1] = "mimeType",
				        [2] = "binary"
			        },
			        new PyList(3)
			        {
				        [0] = reader.GetInt32(5),
				        [1] = reader.GetString(6),
				        [2] = reader.GetInt32(7)
			        }
		        );

		        Row entryRow = new Row(
			        new PyList<PyString>(8)
			        {
				        [0] = "channelID",
				        [1] = "messageID",
				        [2] = "senderID",
				        [3] = "subject",
				        [4] = "body",
				        [5] = "created",
				        [6] = "mimeType",
				        [7] = "deleted"
			        },
			        new PyList(8)
			        {
				        [0] = reader.GetInt32(0),
				        [1] = reader.GetInt32(1),
				        [2] = reader.GetInt32(2),
				        [3] = reader.GetString(3),
				        [4] = reader.GetString(4),
				        [5] = reader.GetInt64(8),
				        [6] = mimeTypeRow,
				        [7] = false
			        }
			    );
		        
		        return new PyTuple(2)
		        {
			        [0] = entryRow,
			        [1] = new PyList() // attachments are not really supported by the client
		        };
	        }
        }

	    public void MarkMessagesRead(int characterID, PyList<PyInteger> messageIDs)
        {
	        Database.Query(
		        $"UPDATE eveMail SET `read` = 1 WHERE messageID IN ({PyString.Join(',', messageIDs)})"
	        );
        }

	    public void DeleteMessages(int characterID, int mailboxID, PyList<PyInteger> messageIDs)
	    {
		    Database.PrepareQuery(
			    $"DELETE FROM eveMail WHERE messageID IN ({PyString.Join(',', messageIDs)} AND channelID = @mailboxID",
			    new Dictionary<string, object>()
			    {
				    {"@mailboxID", mailboxID}
			    }
		    );
	    }

	    public ulong StoreMail(int channelID, int senderID, string subject, string message, out string mailboxType)
        {
	        ulong messageID = Database.PrepareQueryLID(
		        "INSERT INTO eveMail (channelID, senderID, subject, body, mimeTypeID, created, `read`)VALUES(@channelID, @senderID, @subject, @body, 2, @created, 0)",
		        new Dictionary<string, object>()
		        {
			        {"@channelID", channelID},
			        {"@senderID", senderID},
			        {"@subject", subject},
			        {"@body", message},
			        {"@created", DateTime.UtcNow.ToFileTimeUtc()}
		        }
	        );
	        
	        mailboxType = "";
	        
	        // check mailbox type
	        MySqlConnection connection = null;
	        MySqlDataReader reader = Database.PrepareQuery(ref connection,
		        "SELECT groupID FROM invItems LEFT JOIN invTypes USING(typeID) WHERE itemID = @itemID",
		        new Dictionary<string, object>()
		        {
			        {"@itemID", channelID}
		        }
	        );
	        
	        using(connection)
	        using (reader)
	        {
		        // bail out if no data was found with some default garbage value
		        if (reader.Read() == true)
		        {
			        switch (reader.GetInt32(0))
			        {
				        case (int) Groups.Character:
					        mailboxType = "charid";
					        break;
				        
				        case (int) Groups.Corporation:
					        mailboxType = "corpid";
					        break;
			        }
		        }
		        else
		        {
			        mailboxType = "charid";
		        }
	        }
	        
	        return messageID;
        }

        public MessagesDB(DatabaseConnection db) : base(db)
        {
        }
    }
}