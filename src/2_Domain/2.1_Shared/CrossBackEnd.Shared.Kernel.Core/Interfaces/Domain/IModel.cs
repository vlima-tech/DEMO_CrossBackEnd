
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain
{
    public interface IModel
    {
        void Dispose();
        ExecutionResult<bool> IsValid();
    }
}