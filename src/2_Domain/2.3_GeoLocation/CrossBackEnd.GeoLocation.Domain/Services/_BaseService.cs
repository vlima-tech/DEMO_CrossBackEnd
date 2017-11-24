
using System;
using System.Linq.Expressions;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.Services;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.GeoLocation.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> repositoryBase)
        { this._baseRepository = repositoryBase; }

        public ExecutionResult<bool> Add(TEntity obj)
        {
            return this._baseRepository.Add(obj);
        }

        public ExecutionResult AddRange(TEntity[] array)
        {
            return this._baseRepository.AddRange(array);
        }
        
        public ExecutionResult<bool> Exists(TEntity item)
        {
            throw new NotImplementedException();
        }

        public ExecutionResult<bool> Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public ExecutionResult<IBaseCollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool tracking)
        {
            return this._baseRepository.Find(predicate, tracking);
        }

        public ExecutionResult<IBaseCollection<TEntity>> GetAll()
        {
            return this._baseRepository.GetAll();
        }

        public ExecutionResult<TEntity> SearchById(Guid id)
        {
            return this.SearchById(id);
        }

        public ExecutionResult<bool> Remove(Guid id)
        {
            return this._baseRepository.Remove(id);
        }

        public ExecutionResult<bool> Update(TEntity obj)
        {
            return this._baseRepository.Update(obj);
        }

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }
    }
}