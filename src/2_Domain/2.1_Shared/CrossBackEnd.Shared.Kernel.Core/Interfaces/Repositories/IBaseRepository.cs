
using System;
using System.Linq;
using System.Linq.Expressions;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : IModel
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
        ExecutionResult<IQueryable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate, bool tracking);
    }
}