
using System;
using System.IO;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossBackEnd.Shared.Infra.IoC
{
    public static class CrossBackEndBootstrapper
    {
        public static void AddConfiguration(this IServiceCollection services)
        {
            var dir = AppContext.BaseDirectory;
            
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSingleton(configuration);
        }

        public static IConfiguration GetConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration;
        }
    }
}