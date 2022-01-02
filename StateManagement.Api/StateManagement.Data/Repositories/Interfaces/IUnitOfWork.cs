using StateManagement.Data.Repositories.Interfaces;

namespace StateManagement.Data.Repositories.Base.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFlowRepository Flows { get; }
        IFlowStateRepository FlowStates { get; }
        IStateRepository States { get; }
        ITaskRepository Tasks { get; }
        ITaskStateHistoryRepository TaskStateHistory { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
