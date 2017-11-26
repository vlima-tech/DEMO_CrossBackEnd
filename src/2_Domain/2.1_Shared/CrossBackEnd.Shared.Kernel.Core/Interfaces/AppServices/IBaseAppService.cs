
using System;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.MVVM;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.AppServices
{
    /*
    public interface IBaseAppService<TViewModel> : IDisposable where TViewModel : BaseViewModel<TViewModel>
    {
        ExecutionResult<bool> Add(TViewModel obj);
        ExecutionResult AddRange(TViewModel[] array);
        ExecutionResult<bool> Update(TViewModel obj);
        ExecutionResult<bool> Remove(Guid id);
        ExecutionResult<bool> Exists(Guid id);
        ExecutionResult<bool> Exists(TViewModel item);
        ExecutionResult<TViewModel> SearchById(Guid id);
        ExecutionResult<IBaseCollection<TViewModel>> GetAll();
        ExecutionResult<IBaseCollection<TViewModel>> Find(Expression<Func<TViewModel, bool>> predicate, bool tracking);
    }
    */

    public interface IBaseAppService<TViewModel> : IDisposable where TViewModel : IBaseViewModel
    {
        ExecutionResult<bool> Add(TViewModel obj);
        ExecutionResult AddRange(TViewModel[] array);
        ExecutionResult<bool> Update(TViewModel obj);
        ExecutionResult<bool> Remove(Guid id);
        ExecutionResult<bool> Exists(Guid id);
        ExecutionResult<bool> Exists(TViewModel item);
        ExecutionResult<TViewModel> SearchById(Guid id);
        ExecutionResult<IBaseCollection<TViewModel>> GetAll();
    }
}