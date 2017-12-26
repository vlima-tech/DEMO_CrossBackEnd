
using CrossBackEnd.Shared.Kernel.Core.Interfaces.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrossBackEnd.CrossPlatform.Core.Collection
{
    public class BaseObservableCollection<TViewModel> : ObservableCollection<TViewModel> where TViewModel : IViewModel
    {
        public void AddRange(IEnumerable<TViewModel> itens)
        {
            foreach (var item in itens)
                base.Add(item);
        }
    }
}