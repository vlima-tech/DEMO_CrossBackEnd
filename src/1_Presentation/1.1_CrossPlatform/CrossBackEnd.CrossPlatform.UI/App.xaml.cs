
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CrossBackEnd.CrossPlatform.UI.Bootstrap.Android;
using Microsoft.Extensions.DependencyInjection;
using System;

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
        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}