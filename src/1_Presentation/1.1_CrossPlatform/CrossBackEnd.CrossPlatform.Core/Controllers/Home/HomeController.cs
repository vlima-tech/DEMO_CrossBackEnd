
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.Home;
using System.Windows.Input;

namespace CrossBackEnd.CrossPlatform.Core.Controllers.Home
{
    public class HomeController : IHomeController
    {
        public ICommand CountryManagerCommand { get; private set; }

        public HomeController()
        {
            
        }
    }
}