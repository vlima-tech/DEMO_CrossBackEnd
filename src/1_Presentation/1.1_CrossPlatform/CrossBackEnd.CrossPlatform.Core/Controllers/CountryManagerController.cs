
using CrossBackEnd.GeoLocation.Application.ViewModels;

namespace CrossBackEnd.CrossPlatform.Core.Controllers
{
    public class CountryManagerController
    {
        public CountryViewModel CountryViewModel { get; set; }

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