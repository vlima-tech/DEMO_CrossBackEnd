
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;

namespace CrossBackEnd.GeoLocation.Domain.Interfaces.Services
{
    public interface ICountryService : IBaseRepository<Country>
    {
    }
}