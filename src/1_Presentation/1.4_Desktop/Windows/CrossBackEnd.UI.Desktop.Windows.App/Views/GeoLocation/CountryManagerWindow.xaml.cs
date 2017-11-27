
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;

namespace CrossBackEnd.UI.Desktop.Windows.App.Views.GeoLocation
{
    /// <summary>
    /// Lógica interna para CountryManagerWindow.xaml
    /// </summary>
    public partial class CountryManagerWindow : Window
    {
        private readonly ICountryManagerController _countryManagerController;

        public CountryManagerWindow()
        {
            InitializeComponent();

            this._countryManagerController = App.Container.GetService<ICountryManagerController>();

            base.DataContext = this._countryManagerController;
        }
    }
}
