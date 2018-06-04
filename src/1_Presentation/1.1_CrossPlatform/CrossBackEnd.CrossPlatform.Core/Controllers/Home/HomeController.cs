
using System.Windows.Input;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.Home;
using CrossBackEnd.CrossPlatform.Abstractions.Interactions;
using CrossBackEnd.CrossPlatform.Abstractions.Navigation;
using CrossBackEnd.CrossPlatform.Core.MVVM;

namespace CrossBackEnd.CrossPlatform.Core.Controllers.Home
{
    public class HomeController : BaseController, IHomeController
    {
        public ICommand ShowCountryPageCommand { get; private set; }

        public HomeController(INavigationService navigationService, IInteractionService interactionService) 
            : base(navigationService, interactionService)
        {
            this.ShowCountryPageCommand = new Command(NavigateToCountryPage);
        }

        private void NavigateToCountryPage()
        {
            this.Navigation.NavigateToAsync<ICountryController>();
        }
    }
}