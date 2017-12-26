
using Microsoft.Extensions.DependencyInjection;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers;
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.Controllers;
using CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation;

namespace CrossBackEnd.CrossPlatform.Infra.IoC
{
    public static class CrossPlatformBootStrapper
    {
        public static void AddCrossPlatform(this IServiceCollection services)
        {
            services.AddScoped<IBaseController, BaseController>();
            services.AddScoped<ICountryManagerController, CountryController>();
        }
    }
}