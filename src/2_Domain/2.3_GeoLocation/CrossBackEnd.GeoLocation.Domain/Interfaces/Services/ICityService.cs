
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Services;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.GeoLocation.Domain.Interfaces.Services
{
    public interface ICityService : IBaseService<City>
    {
        ExecutionResult<IBaseCollection<City>> FindSimilarCities(string text);
    }
}