
using AutoMapper;
using CrossBackEnd.GeoLocation.Application.AppServices;
using CrossBackEnd.GeoLocation.Application.Interfaces;
using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Interfaces.Services;
using CrossBackEnd.GeoLocation.Domain.Services;
using CrossBackEnd.GeoLocation.Infra.Client.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Linq;
using System.Reflection;

namespace CrossBackEnd.UI.Desktop.Windows.IoC
{
    public static class GeoLocationBootStrapper
    {
        public static void AddGeoLocation(this Container container)
        {
            
            
            var profiles = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => typeof(AutoMapper.Profile).IsAssignableFrom(x));

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as AutoMapper.Profile);
                }
            });
            
            container.RegisterSingleton<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));

            

            // App Service Register's
            container.Register<ICountryAppService, CountryAppService>(Lifestyle.Transient);

            // Service REgister's
            container.Register<ICountryService, CountryService>(Lifestyle.Scoped);

            // Repository Register's
            container.Register<ICountryRepository, CountryRepository>(Lifestyle.Scoped);
            
        }
    }
}