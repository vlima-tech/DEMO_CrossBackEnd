
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.GeoLocation.Application.ViewModels;
using System.Windows.Input;

namespace CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation
{
    public class CountryManagerController : BaseController, ICountryManagerController
    {
        public CountryViewModel CountryViewModel { get; private set; }
        public ICommand SaveCommand { get; private set; }
        
        public CountryManagerController()
        {
            this.CountryViewModel = new CountryViewModel
            {
                Name = "Argentina",
                Abbreviation = "ARG"
            };
        }

    }
}