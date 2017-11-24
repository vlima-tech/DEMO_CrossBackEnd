
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.GeoLocation.Domain.Interfaces.Services
{
    public interface ICityService : IBaseRepository<City>
    {
        ExecutionResult<IBaseCollection<City>> FindSimilarCities(string text);
    }
}