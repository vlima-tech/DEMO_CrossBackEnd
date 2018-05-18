
using System;

using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;

namespace CrossBackEnd.Shared.Kernel.Core.ValueObjects
{
    public class ExecutionResult<TResult>
    {
        public IBaseCollection<Message> Errors { get; private set; }
        public IBaseCollection<Message> SystemErrors { get; private set; }
        public TResult ReturnResult { get; private set; }
        public DateTime Time { get; private set; }
        public bool Success { get { return !this.HasErrors(); } }

        public ExecutionResult()
        {
            this.Time = DateTime.Now;
            this.Errors = new BaseCollection<Message>();
            this.SystemErrors = new BaseCollection<Message>();
            
            if (typeof(TResult).IsClass)
                this.ReturnResult = Activator.CreateInstance<TResult>();
        }
        
        public void DefineResult(TResult result)
        { this.ReturnResult = result; }

        private bool HasErrors()
        { return this.Errors.Count.Equals(0) && this.SystemErrors.Count.Equals(0); }
    }

    public class ExecutionResult
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

        private bool HasErrors()
        {
            //return this.Errors.Count.Equals(0) && this.SystemErrors.Count.Equals(0);

            return false;
        }
    }
}