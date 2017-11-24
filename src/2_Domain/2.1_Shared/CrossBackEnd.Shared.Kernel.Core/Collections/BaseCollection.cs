
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossBackEnd.Shared.Kernel.Core.Collections
{
    public class BaseCollection<T> : List<T>, IBaseCollection<T>
    {
        #region Constructors

        public BaseCollection()
        { }

        public BaseCollection(List<T> collection)
        { this.AddRange(collection); }

        public BaseCollection(T[] array)
        { this.AddRange(array); }

        public BaseCollection(ICollection<T> collection)
        { this.AddRange(collection); }

        public BaseCollection(IEnumerable<T> collection)
        { this.AddRange(collection); }

        #endregion

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }

        public void ForEach(Func<T, bool> match, Action<T> action)
        {
            this.Where(match)
                .ToList()
                .ForEach(action);
        }

        public bool Contains(Func<T, bool> predicade)
        { return this.Where(predicade).Count() > 0; }

        public void AddRange(T[] array)
        { base.AddRange(array.AsEnumerable()); }

        public void AddRange(IList<T> collection)
        { base.AddRange(collection); }
    }
}