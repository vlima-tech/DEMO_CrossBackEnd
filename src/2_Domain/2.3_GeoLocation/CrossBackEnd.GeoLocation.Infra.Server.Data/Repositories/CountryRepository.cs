
using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.GeoLocation.Infra.Server.Data.Context;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(GeoLocation_Context context) : base(context)
        {

        }
    }
}