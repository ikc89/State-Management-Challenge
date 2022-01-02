using StateManagement.Business.ViewModels;

namespace StateManagement.Business.Services.Base
{
    public interface ITaskService
    {
        Task CreateTaskAsync(TaskViewModel model, CancellationToken cancellationToken);
        Task UpdateTaskAsync(TaskViewModel model, CancellationToken cancellationToken);
        IEnumerable<Data.Entities.Task> GetTasks();
        Task<Data.Entities.Task?> GetTaskAsync(int id, CancellationToken cancellationToken);
        Task DeleteTaskAsync(int id, CancellationToken cancellationToken);
        IQueryable<Data.Entities.TaskStateHistory> GetTaskStateHistory();
        Task DeleteTaskStateHistoryAsync(int id, CancellationToken cancellationToken);
    }
}
