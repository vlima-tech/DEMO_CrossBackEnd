
using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers;
using CrossBackEnd.CrossPlatform.Abstractions.Navigation;
using CrossBackEnd.CrossPlatform.Core.Controllers;
using CrossBackEnd.CrossPlatform.UI.Bootstrap.Android;
using CrossBackEnd.CrossPlatform.UI.Bootstrap.Windows;
using CrossBackEnd.CrossPlatform.UI.Views._Navigation;
using CrossBackEnd.CrossPlatform.UI.Mapping;
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.Home;

namespace CrossBackEnd.CrossPlatform.UI.Services
{
    public class NavigationService : INavigationService
    {
        protected readonly PageControllerMap _pageMap;
        private readonly IServiceProvider _container;

        private Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public NavigationService(IServiceProvider container)
        {
            this._pageMap = new PageControllerMap();

            this._container = container;
        }

        public async Task InitializeAsync()
        {
            Page rootPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    rootPage = new AndroidRootPage();
                break;

                case Device.WPF:
                    rootPage = new WindowsRootPage();
                break;
            }

            if (rootPage is MasterDetailPage)
            {
                (rootPage as MasterDetailPage).Detail = new AppNavigationPage(this.CreateAndBindPage<IHomeController>());
                this.CurrentApplication.MainPage = rootPage;
            }
            else
                this.CurrentApplication.MainPage = new AppNavigationPage(rootPage);

            await Task.FromResult(true);
        }
        
        public async Task NavigateBackAsync()
        {
            await this.CurrentApplication.MainPage.Navigation.PopAsync(true);
        }

        public Task NavigateBackModalAsync()
        {
            return this.CurrentApplication.MainPage.Navigation.PopModalAsync(true);
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            var mainPage = this.CurrentApplication.MainPage;

            if (mainPage.Navigation.NavigationStack.Count > 1)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]
                );
            }

            mainPage = null;

            return Task.FromResult(true);
        }
        
        protected Page CreateAndBindPage(Type controllerType, object parameter = null)
        {
            var pageType = this._pageMap.GetPageTypeForController(controllerType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {controllerType} is not a page");
            }

            var page = Activator.CreateInstance(pageType) as Page;

            page.BindingContext = this._container.GetService(controllerType) as BaseController;

            return page;
        }

        protected Page CreateAndBindPage<TController>(object parameter = null) where TController : IBaseController
        {
            var pageType = this._pageMap.GetPageTypeForController<TController>();

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {pageType} is not a page");
            }

            var page = Activator.CreateInstance(pageType) as Page;

            page.BindingContext = this._container.GetService(typeof(TController)) as BaseController;

            return page;
        }

        public Task NavigateToAsync<TController>(object parameter = null, bool animate = true) where TController : IBaseController
        {
            return InternalNavigateToAsync(typeof(TController), parameter);
        }
        
        public Task NavigateToAsync(Type controllerType, object parameter = null, bool animate = true)
        {
            return InternalNavigateToAsync(controllerType, parameter, animate);
        }
        
        protected virtual async Task InternalNavigateToAsync(Type controllerType, object parameter = null, bool animate = true)
        {
            var page = CreateAndBindPage(controllerType, parameter);
            
            var navigation = this.GetNavigation();

            if (navigation != null)
                await navigation.PushAsync(page);
        }

        private INavigation GetNavigation()
        {
            if (this.CurrentApplication.MainPage is AppNavigationPage)
                return (this.CurrentApplication.MainPage as AppNavigationPage).Navigation;

            if (this.CurrentApplication.MainPage is MasterDetailPage)
                return (this.CurrentApplication.MainPage as MasterDetailPage).Detail?.Navigation;
            else
                return this.CurrentApplication.MainPage.Navigation;
        }
        
        public Task NavigateToModalAsync<TController>(object parameter, bool animate) where TController : IBaseController
        {
            return this.InternalNavigateToModalAsync(typeof(TController), parameter);
        }
        
        public Task NavigateToModalAsync(Type controllerType, object parameter = null, bool animate = true)
        {
            return InternalNavigateToModalAsync(controllerType, parameter, animate);
        }

        protected virtual async Task InternalNavigateToModalAsync(Type controllerType, object parameter = null, bool animate = true)
        {
            var page = CreateAndBindPage(controllerType, parameter);

            var navigation = this.GetNavigation();

            if (navigation != null)
                await navigation.PushModalAsync(page);
        }
        
        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }
    }
}