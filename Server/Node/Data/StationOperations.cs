using System.Collections.Generic;

namespace Node.Data
{
    public class StationOperations
    {
        private List<int> mServices;
        private int mOperationID;
        private string mName;
        private string mDescription;

        public StationOperations(int operationID, string name, string description, List<int> services)
        {
            this.mOperationID = operationID;
            this.mServices = services;
        }

        public int OperationID => this.mOperationID;
        public string Name => this.mName;
        public string Description => this.mDescription;
        public List<int> Services => this.mServices;
        public int ServiceMask
        {
            get
            {
                int value = 0;

                foreach (int service in this.mServices)
                    value |= service;

                return value;
            }
        }
    }
}