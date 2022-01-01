using StateManagement.Data.Repositories.Interfaces;

namespace StateManagement.Data.Repositories.Base.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFlowRepository Flows { get; }
        IStateRepository States { get; }
        ITaskRepository Tasks { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
