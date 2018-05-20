
using CrossBackEnd.Shared.Kernel.Core.Interfaces;
using System.Threading.Tasks;

namespace CrossBackEnd.Shared.Infra.Abstractions
{
    public interface IRequestService
    {
        IExecutionResult<TResult> Get<TResult>(string uri, string token = "");
        
        Task<IExecutionResult<TResult>> GetAsync<TResult>(string uri, string token = "");

        Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "");

        Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "");

        Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "");

        Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string token = "");
    }
}