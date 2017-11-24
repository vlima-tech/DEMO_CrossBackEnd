
using System;
using System.Linq.Expressions;

using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;

namespace CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories
{
    public interface ICityRepository : IBaseRepository<City>
    {
        IBaseCollection<City> Find(Expression<Func<City, bool>> predicate, bool tracking, bool includeState);
    }
}