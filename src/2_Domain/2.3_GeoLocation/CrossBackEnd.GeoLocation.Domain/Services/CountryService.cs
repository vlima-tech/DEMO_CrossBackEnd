
using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Interfaces.Services;
using CrossBackEnd.GeoLocation.Domain.Models;

namespace CrossBackEnd.GeoLocation.Domain.Services
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        public CountryService(ICountryRepository countryRepository) : base(countryRepository)
        {
        }
    }
}