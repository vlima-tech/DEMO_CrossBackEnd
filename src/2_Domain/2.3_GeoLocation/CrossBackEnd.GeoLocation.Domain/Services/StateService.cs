
using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Interfaces.Services;
using CrossBackEnd.GeoLocation.Domain.Models;

namespace CrossBackEnd.GeoLocation.Domain.Services
{
    public class StateService : BaseService<State>, IStateService
    {
        public StateService(IStateRepository stateRepository) : base(stateRepository)
        {

        }
    }
}