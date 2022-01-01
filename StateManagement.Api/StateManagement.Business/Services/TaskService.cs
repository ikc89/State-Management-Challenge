using Microsoft.Extensions.Logging;
using StateManagement.Business.Services.Base;
using StateManagement.Data.Repositories.Base.Interfaces;

namespace StateManagement.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TaskService> _logger;

        public TaskService(
            IUnitOfWork unitOfWork,
            ILogger<TaskService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task CreateTaskAsync(Data.Entities.Task task, CancellationToken cancellationToken)
        {
            await _unitOfWork.Tasks.AddAsync(task, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task UpdateTaskAsync(Data.Entities.Task model, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.SingleOrDefaultAsync(x => x.Id == model.Id && x.DeleteDate == null, cancellationToken);
            if (task == null)
            {
                throw new Exception($"Task is not found or may be deleted with id: {model.Id}");
            }

            _unitOfWork.Tasks.Update(task);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public IEnumerable<Data.Entities.Task> GetTasks()
        {
            return _unitOfWork.Tasks.GetAllAsQuery().Where(x => x.DeleteDate == null).ToList();
        }

        public async Task<Data.Entities.Task?> GetTaskAsync(int id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Tasks.GetByIdAsync(id, cancellationToken);
        }

        public async Task DeleteTaskAsync(int id, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.SingleOrDefaultAsync(x => x.Id == id && x.DeleteDate == null, cancellationToken);
            if (task == null)
            {
                throw new Exception($"Task is not found or may be deleted with id: {id}");
            }

            task.DeleteDate = DateTime.UtcNow;

            _unitOfWork.Tasks.Update(task);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
