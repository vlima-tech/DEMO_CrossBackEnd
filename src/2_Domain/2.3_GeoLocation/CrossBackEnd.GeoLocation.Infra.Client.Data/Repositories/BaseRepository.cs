
using System;
using System.Net;
using System.Linq;
using System.Linq.Expressions;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.GeoLocation.Infra.Client.Data.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class, IModel
    {
        private readonly IWebRequestCreate _webRequest;

        public BaseRepository()
        {
//            this._webRequest = WebRequest.cr
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
            throw new NotImplementedException();
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