
using System;
using System.Linq.Expressions;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.Services;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using System.Threading.Tasks;
using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces;

namespace CrossBackEnd.GeoLocation.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : IModel
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> repositoryBase)
        { this._baseRepository = repositoryBase; }

        public ExecutionResult<bool> Add(TEntity obj)
        {
            return this._baseRepository.Save(obj);
        }

        public ExecutionResult AddRange(TEntity[] array)
        {
            return this._baseRepository.SaveRange(array);
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

        public IExecutionResult<BaseCollection<TEntity>> LoadAll()
        {
            return this._baseRepository.GetAll();
        }

        public async Task<IExecutionResult<BaseCollection<TEntity>>> LoadAllAsync()
        {   
            return this._baseRepository.GetAllAsync().GetAwaiter().GetResult();
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