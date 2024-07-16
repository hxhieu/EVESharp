using EVESharp.Types;

namespace EVESharp.StandaloneServer.Exceptions
{
    internal interface IClientResponseException
    {
        public PyDataType ClientResponse { get; }
    }
}
