
using System;
using System.Threading.Tasks;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers;

namespace CrossBackEnd.CrossPlatform.Abstractions.Navigation
{
    public interface INavigationService : IDisposable
    {
        Task InitializeAsync();

        Task NavigateBackAsync();

        Task RemoveLastFromBackStackAsync();
        
        Task NavigateToAsync<TController>(object parameter = null, bool animate = true) where TController : IBaseController;
        
        Task NavigateToAsync(Type controllerType, object parameter = null, bool animate = true);
        
        Task NavigateToModalAsync<TController>(object parameter = null, bool animate = true) where TController : IBaseController;
        
        Task NavigateToModalAsync(Type controllerType, object parameter = null, bool animate = true);

        Task NavigateBackModalAsync();
    }
}