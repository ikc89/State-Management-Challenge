using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StateManagement.Business.Services.Base;
using StateManagement.Business.ViewModels;
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

        public async Task CreateTaskAsync(TaskViewModel model, CancellationToken cancellationToken)
        {
            var task = new Data.Entities.Task
            {
                Name = model.Name,
                FlowId = model.FlowId,
                StateId = model.StateId
            };

            await _unitOfWork.Tasks.AddAsync(task, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task UpdateTaskAsync(TaskViewModel model, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.SingleOrDefaultAsync(x => x.Id == model.Id && x.DeleteDate == null, cancellationToken);
            if (task == null)
            {
                throw new Exception($"Task is not found or may be deleted with id: {model.Id}");
            }

            var flow = await _unitOfWork.Flows.SingleOrDefaultAsync(x => x.Id == model.Id && x.DeleteDate == null, cancellationToken);
            if (flow == null)
            {
                throw new Exception($"Flow is not found or may be deleted with id: {model.Id}");
            }

            task.FlowId = model.FlowId != 0 ? model.FlowId : task.FlowId;
            task.StateId = model.StateId;

            _unitOfWork.Tasks.Update(task);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public IEnumerable<Data.Entities.Task> GetTasks()
        {
            return _unitOfWork.Tasks.GetAllAsQuery().Where(x => x.DeleteDate == null).ToList();
        }

        public async Task<Data.Entities.Task?> GetTaskAsync(int id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Tasks.GetAllAsQuery().Where(x => x.Id == id).Include(x => x.CurrentFlow).ThenInclude(x => x.States).FirstOrDefaultAsync(cancellationToken);
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

        public IQueryable<Data.Entities.TaskStateHistory> GetTaskStateHistory()
        {
            return _unitOfWork.TaskStateHistory.GetAllAsQuery().Where(x => x.DeleteDate == null);
        }

        public async Task DeleteTaskStateHistoryAsync(int id, CancellationToken cancellationToken)
        {
            var taskStateHistory = await _unitOfWork.TaskStateHistory.SingleOrDefaultAsync(x => x.Id == id && x.DeleteDate == null, cancellationToken);
            if (taskStateHistory == null)
            {
                throw new Exception($"Task state history is not found or may be deleted with id: {id}");
            }

            taskStateHistory.DeleteDate = DateTime.UtcNow;

            _unitOfWork.TaskStateHistory.Update(taskStateHistory);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
