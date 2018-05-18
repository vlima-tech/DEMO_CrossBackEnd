
using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using CrossBackEnd.Shared.Infra.Abstractions;
using CrossBackEnd.Shared.Infra.Converters;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.GeoLocation.Application.ViewModels;
using System.Collections.Generic;

namespace CrossBackEnd.Shared.Infra.Services
{
    public class RequestService : IRequestService
    {
        private JsonSerializerSettings _serializerSettings { get; }

        public RequestService()
        {
            this._serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            this._serializerSettings.Converters.Add(new StringEnumConverter());
           // this._serializerSettings.Converters.Add(new GuidConverter());
        }

        public TResult Get<TResult>(string uri, string token = "")
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

            var item = JsonConvert.DeserializeObject<TResult>(content, this._serializerSettings);
            
            return item;
        }

        public Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            HttpClient request = new HttpClient();
            HttpResponseMessage response;
            string content;

            response = request.GetAsync(uri).GetAwaiter().GetResult();

            content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            
            TResult item = JsonConvert.DeserializeObject<TResult>(content, this._serializerSettings);

            return Task.FromResult(item);
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