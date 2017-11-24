
using CrossBackEnd.GeoLocation.Infra.Server.Data.Context;
using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly GeoLocation_Context _baseRepository;

        public BaseRepository(GeoLocation_Context geoLocationContext)
        { this._baseRepository = geoLocationContext; }

        public ExecutionResult<bool> Add(TEntity obj)
        {
            ExecutionResult<bool> execResult = new ExecutionResult<bool>();
            int result;

            this._baseRepository.Set<TEntity>().Add(obj);

            try
            {
                result = this._baseRepository.SaveChanges();

                if (result < 0)
                    execResult.Errors.Add(new Message("As informações não foram salvas e erros não foram retornados."));
            }
            catch(Exception e)
            {
                execResult.SystemErrors.Add(
                    new Message(string.Format("Erro ao salvar a Entidade {0}:{1}", obj.ToString(), e.Message.ToString()))
                );
            }
            
            return execResult;
        }

        public ExecutionResult AddRange(TEntity[] array)
        {
            ExecutionResult execResult = new ExecutionResult();

            this._baseRepository.Set<TEntity>().AddRange(array);

            try
            {
                this._baseRepository.SaveChanges();
            }
            catch(Exception e)
            {
                execResult.SystemErrors.Add(
                    Message.CreateMessage(
                        string.Format(
                            "Erro ao salvar um conjunto de entidades do tipo {0}: {1}", 
                            typeof(TEntity).ToString(), 
                            e.Message.ToString()
                        )
                    )
                );
            }

            return execResult;
        }
        
        public ExecutionResult<IBaseCollection<TEntity>> GetAll()
        {
            ExecutionResult<IBaseCollection<TEntity>> execResult = new ExecutionResult<IBaseCollection<TEntity>>();

            execResult.ReturnResult.AddRange(
                this._baseRepository.Set<TEntity>()
                    .ToList()
            );

            return execResult;
        }
        
        public ExecutionResult<bool> Remove(Guid id)
        {
            ExecutionResult<bool> exectResult = new ExecutionResult<bool>();

            var result = this._baseRepository.Set<TEntity>()
                .Remove(
                    this._baseRepository.Set<TEntity>().Find(id)
                );

            if (!result.State.Equals(EntityState.Deleted))
            {
                exectResult.Errors.Add(
                    new Message(string.Format("", 0))
                );
            }

            return exectResult;
        }

        public bool Update(TEntity obj)
        {
            var result = this._baseRepository.Set<TEntity>().Update(obj);

            if (result.State.Equals(EntityState.Modified))
                return true;
            else
                return false;
        }

        public IBaseCollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool tracking)
        {
            var result = new BaseCollection<TEntity>();

            if (tracking)
            {
                result.AddRange(
                    this._baseRepository.Set<TEntity>()
                        .Where(predicate)
                );
            }
            else
            {
                result.AddRange(
                    this._baseRepository.Set<TEntity>()
                        .AsNoTracking()
                        .Where(predicate)
                );
            }

            return result;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool tracking)
        {
            if (tracking)
                return this._baseRepository.Set<TEntity>().Where(predicate);
            else
            {
                return this._baseRepository.Set<TEntity>()
                    .AsNoTracking()
                    .Where(predicate);
            }
        }

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }
    }
}