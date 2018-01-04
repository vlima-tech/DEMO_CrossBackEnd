
using System;
using System.Windows.Input;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.Collection;
using CrossBackEnd.CrossPlatform.Core.MVVM;
using CrossBackEnd.GeoLocation.Application.Interfaces;
using CrossBackEnd.GeoLocation.Application.ViewModels;

namespace CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation
{
    public class CountryController : BaseController, ICountryController
    {
        public CountryCollection Countries { get; private set; }
        private string searchText = "";
        private bool countryExists = true;
        private bool countryNotExists = false;
        
        public ICommand SearchCommand { get; private set; }
        
        private readonly ICountryAppService _countryAppService;

        #region Gets and Sets

        public bool CountryNotExists
        {
            get { return countryNotExists; }
            set
            {
                countryExists = !value;

                SetProperty(ref countryNotExists, value);

                OnPropertyChanged(() => CountryExists);
            }
        }

        public bool CountryExists
        {
            get { return countryExists; }
            set
            {
                countryNotExists = !value;

                SetProperty(ref countryExists, value);

                OnPropertyChanged(() => CountryNotExists);
            }
        }

        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }

        #endregion

        public CountryController(ICountryAppService countryAppService)
        {
            this.Title = "Countries";

            this._countryAppService = countryAppService;

            this.Countries = new CountryCollection();

            this.SearchCommand = new Command<string>(SearchCountryCommand);

            this.LoadCountries();
        }

        private void LoadCountries()
        {
            var execResult = this._countryAppService.GetAll();


        }
        
        private void SearchCountryCommand(string searchText)
        {

        }
    }
}