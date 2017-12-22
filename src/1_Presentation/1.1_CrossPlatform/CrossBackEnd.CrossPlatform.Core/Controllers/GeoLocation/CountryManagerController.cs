
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.MVVM;
using CrossBackEnd.GeoLocation.Application.Interfaces;
using CrossBackEnd.GeoLocation.Application.ViewModels;

namespace CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation
{
    public class CountryManagerController : BaseController, ICountryManagerController
    {
        public ObservableCollection<CountryViewModel> Countries { get; private set; }
        public CountryViewModel CountryViewModel { get; private set; }
        private string searchText = "";
        private bool countryExists = true;
        private bool countryNotExists = false;
        
        public ICommand AddCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        
        private readonly ICountryAppService _coutryAppService;

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

        public CountryManagerController(ICountryAppService countryAppService)
        {
            this.Title = "Country Manager!!";

            this._coutryAppService = countryAppService;

            this.Countries = new ObservableCollection<CountryViewModel>();
            
            this.CountryViewModel = new CountryViewModel
            {
                Name = "Argentina",
                Abbreviation = "ARG"
            };

            this.AddCommand = new Command<string>(AddCountryCommand);
            this.SaveCommand = new Command(SaveCountryCommand);
            this.SearchCommand = new Command<string>(SearchCountryCommand);
            this.DeleteCommand = new Command(DeleCountryCommand);


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