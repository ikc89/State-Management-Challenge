using StateManagement.Data.Context;
using StateManagement.Data.Repositories.Base;
using StateManagement.Data.Repositories.Interfaces;

namespace StateManagement.Data.Repositories
{
    public class TaskRepository : Repository<Entities.Task>, ITaskRepository
    {
        public TaskRepository(StateManagementContext context)
            : base(context)
        {

        }
    }
}
