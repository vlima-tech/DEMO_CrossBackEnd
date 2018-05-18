
using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Infra.Abstractions;
using Microsoft.Extensions.Configuration;

namespace CrossBackEnd.GeoLocation.Infra.Client.Data.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(IRequestService requestService, IConfiguration configuration)
            :base(requestService, configuration)
        {

        }
        
    }
}