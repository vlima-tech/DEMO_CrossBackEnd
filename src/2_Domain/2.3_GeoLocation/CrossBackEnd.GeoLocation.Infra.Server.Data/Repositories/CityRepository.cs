
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

using CrossBackEnd.GeoLocation.Domain.Interfaces.Repositories;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.GeoLocation.Infra.Server.Data.Context;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(GeoLocation_Context context) : base(context)
        {
            
        }

        public IExecutionResult<BaseCollection<City>> Find(Expression<Func<City, bool>> predicate, bool tracking, bool includeState)
        {
            var execResult = new ExecutionResult<BaseCollection<City>>();
            
            if (includeState)
            {
                execResult.DefineResult(
                    new BaseCollection<City>(
                        base.Where(predicate, tracking)
                            .ReturnResult
                            .Include(c => c.State)
                            .ToListAsync()
                            .GetAwaiter()
                            .GetResult()
                    )
                );
            }
            else
            {
                execResult.DefineResult(
                    new BaseCollection<City>(
                        base.Where(predicate, tracking)
                            .ReturnResult
                            .ToListAsync()
                            .GetAwaiter()
                            .GetResult()
                    )
                );
            }

            return execResult;
        }
    }
}