
using System.Linq;

using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Interfaces.Services;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.GeoLocation.Domain.Specifications;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.GeoLocation.Domain.Services
{
    public class CityService : BaseService<City>, ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository) : base(cityRepository)
        {
            this._cityRepository = cityRepository;
        }

        public ExecutionResult<IBaseCollection<City>> FindSimilarCities(string text)
        {
            ExecutionResult<IBaseCollection<City>> cities = new ExecutionResult<IBaseCollection<City>>();

            cities.ReturnResult.AddRange(
                this._cityRepository.Find(IdentifyCitySpec.IdentifyCity(text), true, false)
                    .ReturnResult
                    .OrderBy(c => c.Name)
            );

            return cities;
        }
    }
}