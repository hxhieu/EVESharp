using AutoMapper;
using EVESharp.EVE.Types.Network;
using EVESharp.StandaloneServer.Messaging;

namespace EVESharp.StandaloneServer.Mapper
{
    internal class PackageProfile : Profile
    {
        public PackageProfile ()
        {
            CreateMap<PyPacket, EveClientPacket> ();
        }
    }
}
