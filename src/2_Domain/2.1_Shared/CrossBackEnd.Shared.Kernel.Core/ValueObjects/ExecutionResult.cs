
using System;

using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;

namespace CrossBackEnd.Shared.Kernel.Core.ValueObjects
{
    public class ExecutionResult<TResult> : ExecutionResult, IExecutionResult<TResult>
    {
        public TResult ReturnResult { get; private set; }
        
        public ExecutionResult() : base()
        {
            if (typeof(TResult).IsClass)
                this.ReturnResult = Activator.CreateInstance<TResult>();
        }
        
        public void DefineResult(TResult result)
        { this.ReturnResult = result; }
    }

    public class ExecutionResult : IExecutionResult
    {
        public IBaseCollection<Message> Errors { get; private set; }
        public IBaseCollection<Message> SystemErrors { get; private set; }
        public DateTime Time { get; private set; }
        public bool Success { get { return !this.HasErrors(); } }

        public ExecutionResult()
        {
            this.Time = DateTime.Now;
            this.Errors = new BaseCollection<Message>();
            this.SystemErrors = new BaseCollection<Message>();
        }

        public bool HasErrors()
        {
            return !this.Errors.Count.Equals(0) && !this.SystemErrors.Count.Equals(0);
        }

        public IExecutionResult Merge(IExecutionResult result, bool updateTime = false)
        {
            var execResult = this;

            execResult.Errors.AddRange(result.Errors);
            execResult.SystemErrors.AddRange(result.SystemErrors);

            if (updateTime)
                execResult.Time = result.Time;

            return execResult;
        }

        public void Dispose()
        {
            GC.Collect(0, GCCollectionMode.Forced);
        }
    }
}