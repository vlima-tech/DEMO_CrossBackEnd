
using System.Threading.Tasks;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers;

namespace CrossBackEnd.CrossPlatform.Abstractions.Interactions
{
    public interface IDialogService
    {
        Task<string> DisplayActionSheet<TController>(string title, string cancel, string destruction, params string[] buttons) where TController : IBaseController;

        Task DisplayAlert<TController>(string title, string message, string cancel) where TController : IBaseController;
        
        Task<bool> DisplayAlert<TController>(string title, string message, string accept, string cancel) where TController : IBaseController;
    }
}