
using System;
using System.Collections.Specialized;
using System.ComponentModel;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.MVVM;

namespace CrossBackEnd.CrossPlatform.Core.Interfaces
{
    public interface IBaseObservableCollection<TViewModel> : IBaseCollection<TViewModel>, IDisposable, INotifyCollectionChanged, INotifyPropertyChanged
        where TViewModel : IViewModel
    {
    }
}