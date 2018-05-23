
using System;
using System.IO;
using System.Reflection;

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CrossBackEnd.CrossPlatform.Infra.IoC;
using CrossBackEnd.CrossPlatform.UI.Bootstrap.Android;
using CrossBackEnd.CrossPlatform.UI.Views._Menus;
using CrossBackEnd.GeoLocation.Infra.Client.IoC;
using CrossBackEnd.CrossPlatform.UI.Bootstrap.Windows;

namespace CrossBackEnd.CrossPlatform.UI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class App : Application
	{
        private IServiceCollection _services { get; set; }
        public static IServiceProvider Container { get; private set; }

        public App()
        {
            InitializeComponent();
            
            this._services = new ServiceCollection();
            
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    MainPage = new AndroidRootPage();
                    break;

                case Device.iOS:
                    break;

                case Device.WPF:
                    MainPage = new WindowsRootPage();
                    break;
            }

            this.ConfigureServices(this._services);
        }
        
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            
            services.AddConfiguration<App>();

            services.AddGeoLocation();
            services.AddCrossPlatform();
            
            services.AddScoped<AndroidRootPage>();
            services.AddScoped<MainMenuPage>();
            
            Container = this._services.BuildServiceProvider();
        }
    }
}