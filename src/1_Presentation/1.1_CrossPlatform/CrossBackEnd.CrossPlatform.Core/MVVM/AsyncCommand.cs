
using System;
using System.Threading.Tasks;

namespace CrossBackEnd.CrossPlatform.Core.MVVM
{
    public class AsyncCommand : Command
    {
        public AsyncCommand(Func<Task> execute) : base(() => execute())
        {
        }
        public AsyncCommand(Func<object, Task> execute) : base(() => execute(null))
        {
        }
    }
}