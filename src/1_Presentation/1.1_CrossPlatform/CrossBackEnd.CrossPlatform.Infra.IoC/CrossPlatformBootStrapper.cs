
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers;
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.Controllers;
using CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation;

namespace CrossBackEnd.CrossPlatform.Infra.IoC
{
    public static class CrossPlatformBootStrapper
    {
        public static void AddConfiguration<TApplication>(this IServiceCollection services)
        {
            var embeddedProvider = new EmbeddedFileProvider(typeof(TApplication).Assembly, typeof(TApplication).Namespace);
            
            var config = new ConfigurationBuilder()
                .AddJsonFile(embeddedProvider, "appsettings.json", true, true)
                .Build();
            
            services.AddSingleton<IConfiguration>(config);
        }

        public static void AddCrossPlatform(this IServiceCollection services)
        {
            services.AddScoped<IBaseController, BaseController>();

            services.AddScoped<ICountryController, CountryController>();
            services.AddScoped<ICountryDetailsController, CountryDetailsController>();
        }
    }
}