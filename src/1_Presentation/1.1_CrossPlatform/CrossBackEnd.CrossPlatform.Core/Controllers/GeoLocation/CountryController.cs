
using System;
using System.Windows.Input;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.Collection;
using CrossBackEnd.CrossPlatform.Core.MVVM;
using CrossBackEnd.GeoLocation.Application.Interfaces;
using CrossBackEnd.GeoLocation.Application.ViewModels;

namespace CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation
{
    public class CountryController : BaseController, ICountryManagerController
    {
        public CountryCollection Countries { get; private set; }
        private string searchText = "";
        private bool countryExists = true;
        private bool countryNotExists = false;
        
        public ICommand AddCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        
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
            this.DeleteCommand = new Command(DeleCountryCommand);


        }

        private void LoadCountries()
        {
            var execResult = this._countryAppService.GetAll();

            
        }

        private void AddCountryCommand(string searchText)
        {

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

        private void SearchCountryCommand(string searchText)
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