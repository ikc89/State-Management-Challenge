namespace StateManagement.Business.Services.Base
{
    public interface ITaskService
    {
        Task CreateTaskAsync(Data.Entities.Task task, CancellationToken cancellationToken);
        Task UpdateTaskAsync(Data.Entities.Task model, CancellationToken cancellationToken);
        IEnumerable<Data.Entities.Task> GetTasks();
        Task<Data.Entities.Task?> GetTaskAsync(int id, CancellationToken cancellationToken);
        Task DeleteTaskAsync(int id, CancellationToken cancellationToken);
    }
}
