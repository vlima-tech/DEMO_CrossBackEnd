
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;

namespace CrossBackEnd.CrossPlatform.UI.Views.GeoLocation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPage : ContentPage
    {
        public CountryPage()
        {
            InitializeComponent();

            this.BindingContext = App.Container.GetService<ICountryController>();
        }
    }
}