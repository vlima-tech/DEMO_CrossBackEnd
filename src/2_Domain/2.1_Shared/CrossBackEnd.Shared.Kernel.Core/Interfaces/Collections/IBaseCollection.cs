
using System;
using System.Collections;
using System.Collections.Generic;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections
{
    public interface IBaseCollection<T> : IDisposable, IList<T>, ICollection<T>,
        IEnumerable<T>, IEnumerable
    {
        void AddRange(IEnumerable<T> collection);
        void AddRange(T[] array);
        void AddRange(IList<T> collection);
        void ForEach(Action<T> action);
        void ForEach(Func<T, bool> match, Action<T> action);
        bool Contains(Func<T, bool> predicade);
        //TDestination ConvertTo<TDestination>(T source, Action<T> converter) where TDestination : class;
    }
}