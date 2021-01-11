using Common.Database;
using Node.Database;
using PythonTypes.Types.Exceptions;
using PythonTypes.Types.Primitives;

namespace Node.Services.Corporations
{
    public class corporationSvc : Service
    {
        private CorporationDB mDB = null;
        
        public corporationSvc(DatabaseConnection db, ServiceManager manager) : base(manager)
        {
            this.mDB = new CorporationDB(db);
        }

        public PyDataType GetFactionInfo(PyDictionary namedPayload, Client client)
        {
            return new PyTuple(new PyDataType[]
            {
                this.mDB.ListAllCorpFactions(), this.mDB.ListAllFactionRegions(), this.mDB.ListAllFactionConstellations(),
                this.mDB.ListAllFactionSolarSystems(), this.mDB.ListAllFactionRaces(), this.mDB.ListAllFactionStationCount(),
                this.mDB.ListAllFactionSolarSystemCount(), this.mDB.ListAllNPCCorporationInfo()
            });
        }

        public PyDataType GetNPCDivisions(PyDictionary namedPayload, Client client)
        {
            return this.mDB.GetNPCDivisions();
        }

        public PyDataType GetMedalsReceived(PyInteger characterID, PyDictionary namedPayload, Client client)
        {
            return new PyTuple(new PyDataType[]
                {
                    this.mDB.GetMedalsReceived(characterID),
                    new PyList() // medal data, rowset medalID, part, layer, graphic, color
                }
            );
        }

        public PyDataType GetEmploymentRecord(PyInteger characterID, PyDictionary namedPayload, Client client)
        {
            return this.mDB.GetEmploymentRecord(characterID);
        }
    }
}