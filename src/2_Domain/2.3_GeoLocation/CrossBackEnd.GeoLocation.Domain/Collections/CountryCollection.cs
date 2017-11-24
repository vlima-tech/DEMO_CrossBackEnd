
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Collections;
using System.Collections.Generic;

namespace CrossBackEnd.GeoLocation.Domain.Collections
{
    public class CountryCollection : BaseCollection<Country>
    {
        public CountryCollection() : base()
        { }
        public CountryCollection(List<Country> collection) : base(collection)
        { }
        public CountryCollection(Country[] array) : base(array)
        { }
        public CountryCollection(ICollection<Country> collection) : base(collection)
        { }
    }
}