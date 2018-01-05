
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CrossBackEnd.Shared.Infra.Abstractions;
using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Configuration;
using CrossBackEnd.Shared.Kernel.Core.Extensions;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.GeoLocation.Infra.Client.Data.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class, IModel
    {
        public IRequestService RequestService { get; private set; }

        public BaseRepository(IRequestService requestService)
        {
            this.RequestService = requestService;
        }

        public virtual ExecutionResult<bool> Add(TModel obj)
        {
            throw new NotImplementedException();
        }

        public virtual ExecutionResult AddRange(TModel[] array)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }

        public virtual ExecutionResult<bool> Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual ExecutionResult<bool> Exists(TModel item)
        {
            throw new NotImplementedException();
        }

        public virtual ExecutionResult<IBaseCollection<TModel>> Find(Expression<Func<TModel, bool>> predicate, bool tracking)
        {
            throw new NotImplementedException();
        }

        public virtual ExecutionResult<IBaseCollection<TModel>> GetAll()
        {
            string className = typeof(TModel).Name;
            string _namespace = typeof(TModel).Namespace
                .Substring(0, typeof(TModel).Namespace.ToLower().IndexOf("domain") - 1);
            
            _namespace = _namespace.Substring(_namespace.LastIndexOf('.') + 1);

            UriBuilder builder = new UriBuilder(Settings.ApiEndPoint);

            builder.AppendToPath("v" + Settings.ApiVersion);
            builder.AppendToPath(_namespace);
            builder.AppendToPath(className);

            var oi = builder.Uri.ToString();

            Teste(oi);

            

            return null;
        }

        private async void Teste(string uri)
        {
            try
            {
                //var result = await this.RequestService.GetAsync<ExecutionResult<IEnumerable<CountryViewModel>>>(uri);
                
            }
            catch (Exception e)
            {

            }
        }

        public virtual ExecutionResult<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual ExecutionResult<TModel> SearchById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual ExecutionResult<bool> Update(TModel obj)
        {
            throw new NotImplementedException();
        }

        public virtual ExecutionResult<IQueryable<TModel>> Where(Expression<Func<TModel, bool>> predicate, bool tracking)
        {
            throw new NotImplementedException();
        }
    }
}