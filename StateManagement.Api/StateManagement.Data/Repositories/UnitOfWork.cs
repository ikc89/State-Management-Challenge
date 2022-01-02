using StateManagement.Data.Context;
using StateManagement.Data.Repositories.Base.Interfaces;
using StateManagement.Data.Repositories.Interfaces;

namespace StateManagement.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StateManagementContext _context;

        private IFlowRepository _flowRepository;
        private IFlowStateRepository _flowStateRepository;
        private IStateRepository _stateRepository;
        private ITaskRepository _taskRepository;
        private ITaskStateHistoryRepository _taskStateHistoryRepository;

        public UnitOfWork(StateManagementContext context)
        {
            _context = context;
        }

        public IFlowRepository Flows => _flowRepository = _flowRepository ?? new FlowRepository(_context);
        public IFlowStateRepository FlowStates => _flowStateRepository ?? new FlowStateRepository(_context);
        public IStateRepository States => _stateRepository ?? new StateRepository(_context);
        public ITaskRepository Tasks => _taskRepository ?? new TaskRepository(_context);
        public ITaskStateHistoryRepository TaskStateHistory => _taskStateHistoryRepository ?? new TaskStateHistoryRepository(_context);

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
