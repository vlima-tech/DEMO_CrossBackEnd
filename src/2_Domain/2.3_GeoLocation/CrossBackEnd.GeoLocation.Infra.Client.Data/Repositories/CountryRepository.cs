
using System.Net;

using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.GeoLocation.Infra.Client.Data.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public override ExecutionResult<IBaseCollection<Country>> GetAll()
        {
          //  var webRequest = WebRequest.Create(@"api/GeoLocation/Country");
            //webRequest.
            return base.GetAll();
        }
    }
}