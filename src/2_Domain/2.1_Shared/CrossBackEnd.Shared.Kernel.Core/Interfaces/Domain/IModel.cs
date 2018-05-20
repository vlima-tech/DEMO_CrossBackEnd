
using System;

using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain
{
    public interface IModel : IDisposable
    {
        ExecutionResult<bool> IsValid();
    }
}