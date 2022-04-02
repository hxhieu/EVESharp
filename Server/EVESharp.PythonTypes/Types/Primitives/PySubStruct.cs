namespace EVESharp.PythonTypes.Types.Primitives
{
    public class PySubStruct : PyDataType
    {
        public PyDataType Definition { get; }

        public PySubStruct(PyDataType definition)
        {
            this.Definition = definition;
        }

        public override int GetHashCode()
        {
            if (this.Definition is null)
                return 0;
            
            return this.Definition.GetHashCode() + 2;
        }
    }
}