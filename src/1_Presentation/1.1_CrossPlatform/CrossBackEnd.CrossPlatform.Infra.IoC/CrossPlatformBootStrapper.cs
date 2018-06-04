
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers;
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.Controllers;
using CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation;
using CrossBackEnd.Shared.Kernel.Core.Configuration;
using CrossBackEnd.CrossPlatform.Core.Controllers.Home;
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.Home;

namespace CrossBackEnd.CrossPlatform.Infra.IoC
{
    public static class CrossPlatformBootStrapper
    {
        public static void AddConfiguration<TApplication>(this IServiceCollection services)
        {
            var embeddedProvider = new EmbeddedFileProvider(typeof(TApplication).Assembly, typeof(TApplication).Namespace);
            
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(embeddedProvider, "appsettings.json", true, true)
                .Build();
            
            services.AddSingleton<IConfiguration>(configuration);
            services.AddOptions();

            services.Configure<Settings>(options => configuration.GetSection("CrossPlatform_Settings").Bind(options));
        }

        public static void AddCrossPlatform(this IServiceCollection services)
        {
            services.AddScoped<IBaseController, BaseController>();

            services.AddScoped<IHomeController, HomeController>();
            services.AddScoped<ICountryController, CountryController>();
            services.AddScoped<ICountryDetailsController, CountryDetailsController>();
        }
    }
}