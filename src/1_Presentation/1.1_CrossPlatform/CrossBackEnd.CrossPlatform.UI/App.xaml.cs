
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

using CrossBackEnd.CrossPlatform.Infra.IoC;
using CrossBackEnd.CrossPlatform.UI.Bootstrap.Android;
using CrossBackEnd.CrossPlatform.UI.Views._Menus;
using CrossBackEnd.GeoLocation.Infra.Client.IoC;

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

            this.ConfigureServices(this._services);
            
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    //MainPage = new HomePage();
                    MainPage = new AndroidRootPage();
                    break;

                case Device.iOS:
                    break;
            }
        }
        
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddGeoLocation();
            services.AddCrossPlatform();
            

            services.AddScoped<AndroidRootPage>();
            services.AddScoped<MainMenuPage>();
            
            Container = this._services.BuildServiceProvider();
        }
    }
}