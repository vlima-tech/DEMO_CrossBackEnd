
using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.GeoLocation.Infra.Server.Data.Context;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Repositories
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(GeoLocation_Context context) : base(context)
        {

        }
    }
}