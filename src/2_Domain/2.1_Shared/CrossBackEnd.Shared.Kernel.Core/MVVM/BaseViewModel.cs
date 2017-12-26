
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.MVVM;
using CrossBackEnd.Shared.Kernel.Core.Collections;

namespace CrossBackEnd.Shared.Kernel.Core.MVVM
{
    public class BaseViewModel<TViewModel> : IViewModel where TViewModel : IViewModel
    {
        public IBaseCollection<ValidationResult> ValidationResult { get; private set; }
        public bool IsValid { get { return this.ValidationResult.Count.Equals(0); } }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public BaseViewModel()
        {
            this.ValidationResult = new BaseCollection<ValidationResult>();
        }
        
        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;

            return true;
        }
        
        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }
    }
}