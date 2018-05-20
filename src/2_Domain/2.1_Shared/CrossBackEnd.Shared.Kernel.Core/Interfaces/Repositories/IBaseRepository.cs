
using System;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseReadOnlyRepository<TEntity>, IDisposable where TEntity : IModel
    {
        ExecutionResult<bool> Save(TEntity obj);
        ExecutionResult SaveRange(TEntity[] array);
        ExecutionResult<bool> Update(TEntity obj);
        ExecutionResult<bool> Remove(Guid id);
    }
}