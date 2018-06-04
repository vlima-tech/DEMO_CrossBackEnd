
using System;

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CrossBackEnd.CrossPlatform.Infra.IoC;
using CrossBackEnd.CrossPlatform.UI.Bootstrap.Android;
using CrossBackEnd.CrossPlatform.UI.Views._Menus;
using CrossBackEnd.GeoLocation.Infra.Client.IoC;
using CrossBackEnd.CrossPlatform.UI.Bootstrap.Windows;
using CrossBackEnd.CrossPlatform.Abstractions.Navigation;
using CrossBackEnd.CrossPlatform.UI.Services;
using CrossBackEnd.CrossPlatform.Abstractions.Interactions;

namespace CrossBackEnd.CrossPlatform.UI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class App : Application
	{
        public static IServiceProvider Container { get; private set; }

        public App()
        {
            InitializeComponent();
            
            this.ConfigureServices(new ServiceCollection());
            
            var nav = new NavigationService(Container);

            nav.InitializeAsync().GetAwaiter().GetResult();
            
        }
        
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddConfiguration<App>();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IInteractionService, InteractionService>();
            
            services.AddGeoLocation();
            services.AddCrossPlatform();

            Container = services.BuildServiceProvider();
        }
    }
}