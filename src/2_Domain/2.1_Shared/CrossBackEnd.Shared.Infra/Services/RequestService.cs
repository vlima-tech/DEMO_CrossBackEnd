
using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using CrossBackEnd.Shared.Infra.Abstractions;
using CrossBackEnd.Shared.Kernel.Core.Interfaces;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.Shared.Infra.Resolvers;
using System.Reflection;
using CrossBackEnd.Shared.Infra.Converters;

namespace CrossBackEnd.Shared.Infra.Services
{
    public class RequestService : IRequestService
    {
        private JsonSerializerSettings _serializerSettings { get; }

        public RequestService()
        {
            this._serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CrossBackEndContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            this._serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public IExecutionResult<TResult> Get<TResult>(string uri, string token = "")
        {
            HttpClient request = new HttpClient();
            HttpResponseMessage response;
            string content;

            response = request.GetAsync(uri)
                                .GetAwaiter()
                                .GetResult();

            content = response.Content.ReadAsStringAsync()
                                        .GetAwaiter()
                                        .GetResult();

            var item = JsonConvert.DeserializeObject<ExecutionResult<TResult>>(content, this._serializerSettings);
            
            return item;
        }

        public async Task<IExecutionResult<TResult>> GetAsync<TResult>(string uri, string token = "")
        {
            HttpClient request = new HttpClient();
            HttpResponseMessage response = null;
            string content;
            IExecutionResult<TResult> item;

            try
            {
                response = request.GetAsync(uri).GetAwaiter().GetResult();

                content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                
                item = JsonConvert.DeserializeObject<ExecutionResult<TResult>>(content, this._serializerSettings);
            }
            catch(Exception e)
            {
                item = new ExecutionResult<TResult>();
                
                item.SystemErrors.Add(new Message(e.Message.ToString()));
            }

            request.Dispose();
            request = null;

            if (response != null)
                response.Dispose();
            
            return item;
        }

        public Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "")
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "")
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "")
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string token = "")
        {
            throw new System.NotImplementedException();
        }
    }
}