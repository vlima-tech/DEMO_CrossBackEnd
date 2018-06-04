
using System;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Abstractions.Navigation;
using CrossBackEnd.GeoLocation.Application.ViewModels;

namespace CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation
{
    public class CountryDetailsController : BaseController, ICountryDetailsController
    {
        public CountryDetailsController(INavigationService navigationService) : base(navigationService)
        {

        }

        private void SaveCountryCommand(object countryViewModel)
        {
            if (countryViewModel is CountryViewModel)
            {

            }
            else
            {

            }
        }

        private void DeleCountryCommand(object countryId)
        {
            if (countryId is Guid)
            {

            }
            else
            {

            }
        }
    }
}