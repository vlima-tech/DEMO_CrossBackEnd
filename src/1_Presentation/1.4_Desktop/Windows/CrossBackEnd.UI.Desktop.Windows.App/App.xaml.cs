
using SimpleInjector;
using System.Windows;

using CrossBackEnd.UI.Desktop.Windows.IoC;
using CrossBackEnd.UI.Desktop.Windows.App.Views;
using CrossBackEnd.UI.Desktop.Windows.App.Views.GeoLocation;

namespace CrossBackEnd.UI.Desktop.Windows.App
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; private set; }

        public App()
        {
            Container = new Container();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Container.Register<_MainWindow>();
            Container.Register<CountryManagerWindow>();
            
            Container.AddCrossPlatform();
            Container.AddGeoLocation();

            Container.Verify();

            base.OnStartup(e);
        }
    }
}