
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories
{
    public interface IBaseReadOnlyRepository<TEntity> : IDisposable where TEntity : IModel
    {
        ExecutionResult<bool> Exists(Guid id);
        ExecutionResult<bool> Exists(TEntity item);
        ExecutionResult<TEntity> SearchById(Guid id);
        IExecutionResult<BaseCollection<TEntity>> GetAll();
        Task<IExecutionResult<BaseCollection<TEntity>>> GetAllAsync();
        ExecutionResult<IBaseCollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool tracking);
        ExecutionResult<IQueryable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate, bool tracking);
    }
}