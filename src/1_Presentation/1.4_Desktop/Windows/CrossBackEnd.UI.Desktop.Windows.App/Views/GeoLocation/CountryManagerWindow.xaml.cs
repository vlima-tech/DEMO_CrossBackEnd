
using System.Windows;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.Controllers;

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

            this._countryManagerController = App.Container.GetInstance<ICountryManagerController>();

            base.DataContext = this._countryManagerController;

        }
    }
}
