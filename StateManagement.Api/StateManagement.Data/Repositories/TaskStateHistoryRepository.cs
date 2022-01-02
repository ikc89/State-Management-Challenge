using StateManagement.Data.Context;
using StateManagement.Data.Entities;
using StateManagement.Data.Repositories.Base;
using StateManagement.Data.Repositories.Interfaces;

namespace StateManagement.Data.Repositories
{
    public class TaskStateHistoryRepository : Repository<TaskStateHistory>, ITaskStateHistoryRepository
    {
        public TaskStateHistoryRepository(StateManagementContext context)
            : base(context)
        {
        }
    }
}
