
using System.Collections.Generic;

using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Collections;

namespace CrossBackEnd.GeoLocation.Domain.Collections
{
    public class CityCollection : BaseCollection<City>
    {
        public CityCollection() : base()
        { }
        public CityCollection(List<City> collection) : base(collection)
        { }
        public CityCollection(City[] array) : base(array)
        { }
        public CityCollection(ICollection<City> collection) : base(collection)
        { }
    }
}