
using CrossBackEnd.GeoLocation.Infra.Server.Data.DataLoad;
using CrossBackEnd.GeoLocation.Infra.Server.Data.DataLoad.Cities;
using CrossBackEnd.GeoLocation.Infra.Server.Data.DataLoad.States;
using System;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            var context = new GeoLocation_Context();

            context.Database.EnsureCreated();

            CountriesInitializer.Initializer(context);
            BrazilStatesInitializer.Initializer(context);
            //BrazilCitiesInitializer.Initializer(context);
            
            context.Dispose();
            context = null;

            GC.Collect(0, GCCollectionMode.Forced);
        }
    }
}