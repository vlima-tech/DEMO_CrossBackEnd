
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.MVVM
{
    /*
    public interface IBaseViewModel<TViewModel> : INotifyPropertyChanged,
        IDisposable where TViewModel : class
    {
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null);
        IBaseCollection<ValidationResult> ValidationResult { get; }
        bool IsValid { get; }
    }
    */

    public interface IBaseViewModel : INotifyPropertyChanged, IDisposable
    {
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null);
        IBaseCollection<ValidationResult> ValidationResult { get; }
        bool IsValid { get; }
    }
}