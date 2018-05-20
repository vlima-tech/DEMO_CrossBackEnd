
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;

namespace CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories
{
    public interface ICountryReadOnlyRepository : IBaseReadOnlyRepository<Country>
    {

    }
}