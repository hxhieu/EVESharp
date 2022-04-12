﻿using System.Collections.Generic;
using EVESharp.EVE.Packets.Complex;
using EVESharp.PythonTypes.Types.Primitives;

namespace EVESharp.Node.Client.Notifications.Chat;

public class OnContactLoggedOn : ClientNotification
{
    private const string NOTIFICATION_NAME = "OnContactLoggedOn";

    public int CharacterID { get; init; }

    public OnContactLoggedOn (int characterID) : base (NOTIFICATION_NAME)
    {
        CharacterID = characterID;
    }

    public override List <PyDataType> GetElements ()
    {
        return new List <PyDataType> {CharacterID};
    }
}