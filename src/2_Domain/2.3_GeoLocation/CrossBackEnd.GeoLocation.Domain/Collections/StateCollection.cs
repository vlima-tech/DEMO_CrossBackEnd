
using System.Collections.Generic;

using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.GeoLocation.Domain.Models;

namespace CrossBackEnd.GeoLocation.Domain.Collections
{
    public class StateCollection : BaseCollection<State>
    {
        public StateCollection() : base()
        { }
        public StateCollection(List<State> collection) : base(collection)
        { }
        public StateCollection(State[] array) : base(array)
        { }
        public StateCollection(ICollection<State> collection) : base(collection)
        { }
    }
}