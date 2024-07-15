using AutoMapper;
using EVESharp.Database.Entity;
using EVESharp.EVE.Sessions;
using EVESharp.StandaloneServer.Server;

namespace EVESharp.StandaloneServer.Mapper
{
    internal class SessionMapperProfile : Profile
    {
        public SessionMapperProfile ()
        {
            // From account
            CreateMap<Account, Session> ()
                .ForMember (dest => dest.UserID, opts => opts.MapFrom (src => src.AccountId))
                .ForMember (dest => dest.Role, opts => opts.MapFrom (src => src.Role))
            ;

            // From connection
            CreateMap<EveTcpSession, Session> ()
                // TODO: Hard code to "EN"
                .ForMember (dest => dest.LanguageID, opts => opts.MapFrom (_ => "EN"))
                // TODO: Only has 1 node?
                .ForMember (dest => dest.NodeID, opts => opts.MapFrom (_ => 1))
                .ForMember (dest => dest.Address, opts => opts.MapFrom (src => src.Socket.RemoteEndPoint != null ? src.Socket.RemoteEndPoint.ToString () : null))
            ;
        }
    }
}
