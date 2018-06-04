
using System.Threading.Tasks;
using System.Windows.Input;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.Collection;
using CrossBackEnd.CrossPlatform.Core.MVVM;
using CrossBackEnd.GeoLocation.Application.Interfaces;

using CrossBackEnd.GeoLocation.Application.ViewModels;
using CrossBackEnd.Shared.Kernel.Core.Interfaces;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.AppServices;
using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.CrossPlatform.Abstractions.Navigation;
using CrossBackEnd.CrossPlatform.Abstractions.Interactions;

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

        public CountryController(ICountryAppService countryAppService, INavigationService navigationService, 
            IInteractionService interactionService) : base(navigationService, interactionService)
        {
            this.Title = "Countries";

            this._countryAppService = countryAppService;

            this.Countries = new CountryCollection();

           // this.SearchCommand = new Command<string>(SearchCountryCommand);
            this.SearchCommand = new AsyncCommand(SearchCountryCommanAsync);

            //this.LoadCountriesAsync();
            //this.LoadCountries();
        }

        private void LoadCountries()
        {
            var execResult = this._countryAppService.LoadAll();
        }
        
        private async void LoadCountriesAsync()
        {
            var execResult = await this._countryAppService.LoadAllAsync();
        }
        
        private void SearchCountryCommand(string searchText)
        {
            var result = this._countryAppService.LoadAll();

            if (result.Success)
            {
                this.Countries.Clear();
                this.Countries.AddRange(result.ReturnResult);
            }

            result.Dispose();
        }
        
        private async Task SearchCountryCommanAsync()
        {
            //var action = await DisplayActionSheet<ICountryController>("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
            
            var result = this._countryAppService.LoadAllAsync().GetAwaiter().GetResult();

            if (result.Success)
            {
                this.Countries.Clear();
                this.Countries.AddRange(result.ReturnResult);
            }
        }
    }
}