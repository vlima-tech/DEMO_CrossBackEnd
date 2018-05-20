
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.Services
{
    public interface IBaseService<TModel> : IDisposable where TModel : IModel
    {
        ExecutionResult<bool> Add(TModel obj);
        ExecutionResult AddRange(TModel[] array);
        ExecutionResult<bool> Update(TModel obj);
        ExecutionResult<bool> Remove(Guid id);
        ExecutionResult<bool> Exists(Guid id);
        ExecutionResult<bool> Exists(TModel item);
        ExecutionResult<TModel> SearchById(Guid id);
        IExecutionResult<BaseCollection<TModel>> LoadAll();
        Task<IExecutionResult<BaseCollection<TModel>>> LoadAllAsync();
        ExecutionResult<IBaseCollection<TModel>> Find(Expression<Func<TModel, bool>> predicate, bool tracking);
    }
}