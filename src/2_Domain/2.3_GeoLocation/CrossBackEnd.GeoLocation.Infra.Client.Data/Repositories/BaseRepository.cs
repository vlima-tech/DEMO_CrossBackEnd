
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using CrossBackEnd.Shared.Infra.Abstractions;
using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Configuration;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.GeoLocation.Infra.Client.Data.Helpers;
using CrossBackEnd.Shared.Kernel.Core.Interfaces;

namespace CrossBackEnd.GeoLocation.Infra.Client.Data.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class, IModel
    {
        public IRequestService RequestService { get; private set; }
        public Settings Settings { get; private set; }

        public BaseRepository(IRequestService requestService, IConfiguration configuration)
        {
            this.RequestService = requestService;
            
            this.Settings = configuration.Get<Settings>();
        }

        public virtual ExecutionResult<bool> Save(TModel obj)
        {
            throw new NotImplementedException();
        }

        public virtual ExecutionResult SaveRange(TModel[] array)
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

        public virtual IExecutionResult<BaseCollection<TModel>> GetAll()
        {
            IExecutionResult<BaseCollection<TModel>> result;
            Uri url;

            url = RouteHelper.GenerateUrl<TModel>(this.Settings.ApiEndPoint, this.Settings.ApiVersion);
            
            result = this.RequestService.Get<BaseCollection<TModel>>(url.ToString());
            
            return result;
        }
        
        public async virtual Task<IExecutionResult<BaseCollection<TModel>>> GetAllAsync()
        {
            IExecutionResult<BaseCollection<TModel>> result;// = new ExecutionResult<BaseCollection<TModel>>();
            Uri url;
            
            url = RouteHelper.GenerateUrl<TModel>(this.Settings.ApiEndPoint, this.Settings.ApiVersion);

            result = await this.RequestService.GetAsync<BaseCollection<TModel>>(url.ToString());

            return result;
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