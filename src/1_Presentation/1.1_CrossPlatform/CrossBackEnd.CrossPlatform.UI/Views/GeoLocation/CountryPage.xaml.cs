
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;

namespace CrossBackEnd.CrossPlatform.UI.Views.GeoLocation
{
    public partial class CountryPage : ContentPage
    {
        public CountryPage()
        {
            InitializeComponent();

            this.BindingContext = App.Container.GetService<ICountryController>();
        }
    }
}