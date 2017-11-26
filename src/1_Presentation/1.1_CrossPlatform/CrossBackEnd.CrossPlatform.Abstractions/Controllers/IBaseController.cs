
using System.Runtime.CompilerServices;

using CrossBackEnd.CrossPlatform.Abstractions.Navigation;

namespace CrossBackEnd.CrossPlatform.Abstractions.Controllers
{
    public interface IBaseController
    {
        string Title { get; }
        string Icon { get; }
        bool IsBusy { get; }
        INavigationService Navigation { get; }
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null);
    }
}