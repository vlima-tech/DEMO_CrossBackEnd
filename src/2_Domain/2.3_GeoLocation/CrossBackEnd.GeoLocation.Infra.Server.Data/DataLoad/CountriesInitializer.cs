
using System;
using System.Linq;

using CrossBackEnd.GeoLocation.Domain.Collections;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.GeoLocation.Infra.Server.Data.Context;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.DataLoad
{
    public class CountriesInitializer
    {
        public static void Initializer(GeoLocation_Context context)
        {
            CountryCollection countries = new CountryCollection();

            if (!context.Countries.Any())
            {
                countries.Add(new Country("Brazil", "BRA"));

                countries.ForEach(x => context.Add(x));
            }

            context.SaveChanges();

            countries.Dispose();
            countries = null;

            GC.Collect(0, GCCollectionMode.Forced);
        }
    }
}