
using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

using AutoMapper;

using CrossBackEnd.GeoLocation.Infra.Client.IoC;
using CrossBackEnd.CrossPlatform.Infra.IoC;

namespace CrossBackEnd.UI.Desktop.Windows.App
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceCollection _services { get; set; }
        public static IServiceProvider Container { get; private set; }

        public App()
        {
            //Container = new Container();
            this._services = new ServiceCollection();

            ConfigureServices(this._services);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddCrossPlatform();
            services.AddGeoLocation();

            Container = services.BuildServiceProvider();
        }
    }
}