
using System;

using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using System.Linq.Expressions;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.Services
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        ExecutionResult<bool> Add(TEntity obj);
        ExecutionResult AddRange(TEntity[] array);
        ExecutionResult<bool> Update(TEntity obj);
        ExecutionResult<bool> Remove(Guid id);
        ExecutionResult<bool> Exists(Guid id);
        ExecutionResult<bool> Exists(TEntity item);
        ExecutionResult<TEntity> SearchById(Guid id);
        ExecutionResult<IBaseCollection<TEntity>> GetAll();
        ExecutionResult<IBaseCollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool tracking);
    }
}