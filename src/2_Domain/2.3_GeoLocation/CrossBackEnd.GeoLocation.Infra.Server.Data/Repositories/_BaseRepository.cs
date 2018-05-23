
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

using CrossBackEnd.GeoLocation.Infra.Server.Data.Context;
using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Repositories;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using System.Threading.Tasks;
using CrossBackEnd.Shared.Kernel.Core.Interfaces;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IModel
    {
        private readonly GeoLocation_Context _baseRepository;

        public BaseRepository(GeoLocation_Context geoLocationContext)
        { this._baseRepository = geoLocationContext; }

        public ExecutionResult<bool> Save(TEntity obj)
        {
            ExecutionResult<bool> execResult = new ExecutionResult<bool>();
            int result;
            
            try
            {
                this._baseRepository.Set<TEntity>().Add(obj);

                result = this._baseRepository.SaveChanges();

                if (result > 0)
                    execResult.DefineResult(true);
                else
                {
                    execResult.DefineResult(false);

                    execResult.Errors.Add(
                        new Message("As informações não foram salvas e erros não foram retornados.")
                    );
                }
            }
            catch(Exception e)
            {
                execResult.SystemErrors.Add(
                    new Message(
                        string.Format("Erro ao salvar a Entidade {0}:{1}", obj.ToString(), e.Message.ToString())
                    )
                );
            }
            
            return execResult;
        }

        public ExecutionResult SaveRange(TEntity[] array)
        {
            ExecutionResult execResult = new ExecutionResult();
            
            try
            {
                this._baseRepository.Set<TEntity>().AddRange(array);

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
        
        public ExecutionResult<bool> Update(TEntity obj)
        {
            var execResult = new ExecutionResult<bool>();

            try
            {
                var result = this._baseRepository.Set<TEntity>().Update(obj);

                if (result.State.Equals(EntityState.Modified))
                    execResult.DefineResult(true);
                else
                    execResult.DefineResult(false);
            }
            catch(Exception e)
            {
                execResult.SystemErrors.Add(new Message(""));
            }
            
            return execResult;
        }
        
        public ExecutionResult<bool> Remove(Guid id)
        {
            ExecutionResult<bool> execResult = new ExecutionResult<bool>();

            try
            {
                var result = this._baseRepository.Set<TEntity>()
                    .Remove(
                        this._baseRepository.Set<TEntity>().Find(id)
                    );

                if (!result.State.Equals(EntityState.Deleted))
                {
                    execResult.DefineResult(false);

                    execResult.Errors.Add(
                        new Message(string.Format("", 0))
                    );
                }
                else
                    execResult.DefineResult(true);
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(new Message(""));
            }

            return execResult;
        }
        
        public ExecutionResult<bool> Exists(Guid id)
        {
            var execResult = new ExecutionResult<bool>();

            try
            {
                var result = this._baseRepository.Set<TEntity>().Find(id);

                if (result != null)
                    execResult.DefineResult(true);
                else
                {
                    execResult.DefineResult(false);
                    execResult.Errors.Add(new Message(""));
                }
            }
            catch(Exception e)
            {
                execResult.DefineResult(false);
                execResult.SystemErrors.Add(new Message(""));
            }


            return execResult;
        }

        public ExecutionResult<bool> Exists(TEntity item)
        {
            var execResult = new ExecutionResult<bool>();

            try
            {
                var result = this._baseRepository.Set<TEntity>().Find(item);

                if (result != null)
                    execResult.DefineResult(true);
                else
                {
                    execResult.DefineResult(false);
                    execResult.Errors.Add(new Message(""));
                }
            }
            catch (Exception e)
            {
                execResult.DefineResult(false);
                execResult.SystemErrors.Add(new Message(""));
            }


            return execResult;
        }

        public ExecutionResult<TEntity> SearchById(Guid id)
        {
            var execResult = new ExecutionResult<TEntity>();

            try
            {
                var result = this._baseRepository.Set<TEntity>().Find(id);

                if (result != null)
                    execResult.DefineResult(result);
                else
                {
                    execResult.DefineResult(null);
                    execResult.Errors.Add(new Message(""));
                }
            }
            catch (Exception e)
            {
                execResult.DefineResult(null);
                execResult.SystemErrors.Add(new Message(""));
            }


            return execResult;
        }

        public IExecutionResult<BaseCollection<TEntity>> GetAll()
        {
            var execResult = new ExecutionResult<BaseCollection<TEntity>>();
            
            execResult.DefineResult(
                new BaseCollection<TEntity>(
                    this._baseRepository.Set<TEntity>()
                        .ToList()
                )
            );

            return execResult;
        }

        public async Task<IExecutionResult<BaseCollection<TEntity>>> GetAllAsync()
        {
            var execResult = new ExecutionResult<BaseCollection<TEntity>>();

            execResult.DefineResult(
                new BaseCollection<TEntity>(
                    await this._baseRepository.Set<TEntity>()
                        .ToListAsync()
                )
            );

            return execResult;
        }

        public ExecutionResult<IBaseCollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool tracking)
        {
            var execResult = new ExecutionResult<IBaseCollection<TEntity>>();

            try
            {
                if (tracking)
                {
                    execResult.DefineResult(
                        new BaseCollection<TEntity>(
                            this._baseRepository.Set<TEntity>()
                                .Where(predicate)
                        )
                    );
                }
                else
                {
                    execResult.DefineResult(
                        new BaseCollection<TEntity>(
                            this._baseRepository.Set<TEntity>()
                                .AsNoTracking()
                                .Where(predicate)
                        )
                    );
                }
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(new Message(""));
            }
            return execResult;
        }

        public ExecutionResult<IQueryable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate, bool tracking)
        {
            var execResult = new ExecutionResult<IQueryable<TEntity>>();

            try
            {
                if (tracking)
                {
                    execResult.DefineResult(
                        this._baseRepository.Set<TEntity>().Where(predicate)
                    );
                }
                else
                {
                    execResult.DefineResult(
                        this._baseRepository.Set<TEntity>()
                            .AsNoTracking()
                            .Where(predicate)
                    );
                }
            }
            catch (Exception e)
            {
                execResult.SystemErrors.Add(new Message(""));
            }

            return execResult;
        }

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }
    }
}