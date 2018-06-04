
using System;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers;
using CrossBackEnd.CrossPlatform.Abstractions.Interactions;
using CrossBackEnd.CrossPlatform.UI.Mapping;

namespace CrossBackEnd.CrossPlatform.UI.Services
{
    public class InteractionService : IInteractionService
    {
        private Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public Task<string> DisplayActionSheet<TController>(string title, string cancel, string destruction, params string[] buttons)
            where TController : IBaseController
        {
            return this.MatchPage(typeof(TController))?.DisplayActionSheet(title, cancel, destruction, buttons);
        }

        public Task DisplayAlert<TController>(string title, string message, string cancel)
            where TController : IBaseController
        {
            return this.MatchPage(typeof(TController))?.DisplayAlert(title, message, cancel);
        }

        public Task<bool> DisplayAlert<TController>(string title, string message, string accept, string cancel)
            where TController : IBaseController
        {
            return this.MatchPage(typeof(TController))?.DisplayAlert(title, message, accept, cancel);
        }
        
        private Page MatchPage(Type type)
        {
            var pageType = new PageControllerMap().GetPageTypeForController(type);
            Page page = null;

            page = this.CurrentApplication.MainPage.Navigation.NavigationStack
                .Where(p => p.GetType().Equals(pageType))
                .FirstOrDefault();

            if (page != null)
                return page;


            page = this.CurrentApplication.MainPage.Navigation.ModalStack
                .Where(p => p.GetType().Equals(pageType))
                .FirstOrDefault();

            if (page != null)
                return page;
            
            return this.CurrentApplication.MainPage;
        }

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }
    }
}