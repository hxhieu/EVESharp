using System.Collections.Generic;
using EVESharp.EVE.Data.Inventory.Station;
using EVESharp.Node.Database;

namespace EVESharp.Node.Inventory;

public class StationManager
{
    private StationDB StationDB { get; }

    public Dictionary <int, Operation> Operations   { get; private set; }
    public Dictionary <int, Type>      StationTypes { get; private set; }
    public Dictionary <int, string>    Services     { get; private set; }

    public StationManager (StationDB stationDB)
    {
        StationDB = stationDB;
    }

    public void Load ()
    {
        Operations   = StationDB.LoadOperations ();
        StationTypes = StationDB.LoadStationTypes ();
        Services     = StationDB.LoadServices ();
    }
}