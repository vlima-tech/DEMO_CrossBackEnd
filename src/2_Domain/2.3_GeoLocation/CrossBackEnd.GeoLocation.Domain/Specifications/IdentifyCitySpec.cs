
using System;
using System.Linq.Expressions;

using CrossBackEnd.GeoLocation.Domain.Models;

namespace CrossBackEnd.GeoLocation.Domain.Specifications
{
    public static class IdentifyCitySpec
    {
        public static Expression<Func<City, bool>> IdentifyCity(string text)
        {
            return c => text.ToLower().Contains(c.Name.ToLower());
        }
    }
}