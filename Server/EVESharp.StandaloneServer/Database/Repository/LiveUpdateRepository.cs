using EVESharp.Database.Entity;
using EVESharp.Database.Entity.Context;

namespace EVESharp.StandaloneServer.Database.Repository
{
    internal interface ILiveUpdateRepository : IGenericRepository<EveLiveUpdate>
    {
    }

    internal class LiveUpdateRepository (EveSharpDbContext dbContext) : GenericRepository<EveLiveUpdate> (dbContext), ILiveUpdateRepository
    {

    }
}
