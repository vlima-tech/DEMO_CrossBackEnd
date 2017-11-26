
using System;
using System.Windows.Input;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.MVVM;
using CrossBackEnd.GeoLocation.Application.Interfaces;
using CrossBackEnd.GeoLocation.Application.ViewModels;

namespace CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation
{
    public class CountryManagerController : BaseController, ICountryManagerController
    {
        public CountryViewModel CountryViewModel { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        
        public CountryManagerController()
        {
            this.CountryViewModel = new CountryViewModel
            {
                Name = "Argentina",
                Abbreviation = "ARG"
            };

            this.SaveCommand = new Command(SaveCountryCommand);
            this.SearchCommand = new Command(SearchCountryCommand);
            this.DeleteCommand = new Command(DeleCountryCommand);
        }

        private void SaveCountryCommand(object countryViewModel)
        {
            if(countryViewModel is CountryViewModel)
            {

            }
            else
            {

            }
        }

        private void SearchCountryCommand(object searchText)
        {

        }

        private void DeleCountryCommand(object countryId)
        {
            if(countryId is Guid)
            {

            }
            else
            {

            }
        }
    }
}