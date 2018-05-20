
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.AppServices;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Services;
using CrossBackEnd.Shared.Kernel.Core.MVVM;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.MVVM;

using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces;

namespace CrossBackEnd.GeoLocation.Application.AppServices
{
    public abstract class BaseAppService<TViewModel, TModel> : IBaseAppService<TViewModel>
        where TViewModel : BaseViewModel<TViewModel>, IViewModel
        where TModel : IModel
    {
        private readonly IBaseService<TModel> _baseService;
        private readonly IMapper _mapper;
        
        public BaseAppService(IBaseService<TModel> baseService, IMapper mapper)
        {
            this._baseService = baseService;
            this._mapper = mapper;
        }
        
        public ExecutionResult<bool> Add(TViewModel obj)
        {
            //return this._baseService.Add(obj);
            return new ExecutionResult<bool>();
        }

        public ExecutionResult AddRange(TViewModel[] array)
        {
            //return this._baseService.AddRange(array);
            return new ExecutionResult();
        }

        public void Dispose()
        {
            GC.Collect(0, GCCollectionMode.Forced);
        }

        public ExecutionResult<bool> Exists(Guid id)
        {
            return this._baseService.Exists(id);
        }

        public ExecutionResult<bool> Exists(TViewModel item)
        {
            //return this._baseService.Exists(item);
            return new ExecutionResult<bool>();
        }
        
        public IExecutionResult<BaseCollection<TViewModel>> LoadAll()
        {
            IExecutionResult<BaseCollection<TViewModel>> execResult = new ExecutionResult<BaseCollection<TViewModel>>();

            execResult.DefineResult(
                this.ConvertModelToViewModel(this._baseService.LoadAll().ReturnResult) as BaseCollection<TViewModel>
            );

            return execResult;
        }

        public async Task<IExecutionResult<BaseCollection<TViewModel>>> LoadAllAsync()
        {
            IExecutionResult<BaseCollection<TViewModel>> execResult = new ExecutionResult<BaseCollection<TViewModel>>();

            var result = await this._baseService.LoadAllAsync();

            execResult.DefineResult(
                this.ConvertModelToViewModel(result.ReturnResult) as BaseCollection<TViewModel>
            );
            
            return execResult;
        }

        public ExecutionResult<bool> Remove(Guid id)
        {
            return this._baseService.Remove(id);
        }

        public ExecutionResult<TViewModel> SearchById(Guid id)
        {
            //return this._baseService.SearchById(id);
            return new ExecutionResult<TViewModel>();
        }

        public ExecutionResult<bool> Update(TViewModel obj)
        {
            //return this._baseService.Update(obj);
            return new ExecutionResult<bool>();
            
        }
        /*
        public TViewModel ConvertModelToViewModel(TModel model)
        {
            return this._mapper.Map<TViewModel>(model);
        }

        public TViewModel ConvertViewModelToModel(TViewModel viewModel)
        {
            return this._mapper.Map<TModel>(viewModel);
        }
        */
        internal abstract TViewModel ConvertModelToViewModel(TModel model);
        internal abstract IBaseCollection<TViewModel> ConvertModelToViewModel(IBaseCollection<TModel> model);
        internal abstract TModel ConvertViewModelToModel(TViewModel viewModel);
        internal abstract IBaseCollection<TModel> ConvertViewModelToModel(IBaseCollection<TViewModel> viewModel);
    }
}