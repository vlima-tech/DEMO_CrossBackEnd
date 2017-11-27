
using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

using AutoMapper;

using CrossBackEnd.GeoLocation.Application.AppServices;
using CrossBackEnd.GeoLocation.Application.Interfaces;
using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Interfaces.Services;
using CrossBackEnd.GeoLocation.Domain.Services;
using CrossBackEnd.GeoLocation.Infra.Client.Data.Repositories;

namespace CrossBackEnd.GeoLocation.Infra.Client.IoC
{
    public static class GeoLocationBootStrapper
    {
        public static IServiceCollection AddGeoLocation(this IServiceCollection services)
        {
            // Application Services
            services.AddScoped<ICountryAppService, CountryAppService>();
            //services.AddScoped<ICityAppService, CityAppService>();
            //services.AddScoped<IStateAppService, StateAppService>();

            // Domain Services
            services.AddScoped<ICountryService, CountryService>();
            //services.AddScoped<ICityService, CityService>();
            //services.AddScoped<IStateService, StateService>();

            // Repository
            services.AddScoped<ICountryRepository, CountryRepository>();
            //services.AddScoped<ICityRepository, CityRepository>();
            //services.AddScoped<IStateRepository, StateRepository>();
            
            return services;
        }
    }
}