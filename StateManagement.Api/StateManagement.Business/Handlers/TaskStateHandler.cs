using Microsoft.Extensions.Logging;
using StateManagement.Business.Handlers.Base;
using StateManagement.Business.Services.Base;
using StateManagement.Business.ViewModels;

namespace StateManagement.Business.Handlers
{
    public class TaskStateHandler : ITaskStateHandler
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskStateHandler> _logger;

        public TaskStateHandler(
            ITaskService taskService,
            ILogger<TaskStateHandler> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        public async Task MoveToNextState(int id, CancellationToken cancellationToken)
        {
            var task = await _taskService.GetTaskAsync(id, cancellationToken);
            var currentFlow = task.CurrentFlow;
            var currentFlowState = task.CurrentFlowState;
            if (currentFlowState.Order == currentFlow.States.Max(x => x.Order))
            {
                return;
            }

            var taskViewModel = new TaskViewModel
            {
                Id = task.Id,
                StateId = currentFlow.States.FirstOrDefault(x => x.Order == currentFlowState.Order + 1).StateId
            };

            await _taskService.UpdateTaskAsync(taskViewModel, cancellationToken);
        }

        public async Task MoveToPreviousState(int id, CancellationToken cancellationToken)
        {
            var task = await _taskService.GetTaskAsync(id, cancellationToken);
            var currentFlow = task.CurrentFlow;
            var currentFlowState = task.CurrentFlowState;
            if (currentFlowState.Order == 1)
            {
                return;
            }

            var taskViewModel = new TaskViewModel
            {
                Id = task.Id,
                StateId = currentFlow.States.FirstOrDefault(x => x.Order == currentFlowState.Order - 1).StateId
            };

            await _taskService.UpdateTaskAsync(taskViewModel, cancellationToken);
        }

        public async Task UndoLastMove(CancellationToken cancellationToken)
        {
            var lastMove = _taskService.GetTaskStateHistory().OrderByDescending(x => x.Id).FirstOrDefault();
            await _taskService.DeleteTaskStateHistoryAsync(lastMove.Id, cancellationToken);

            var previousThanLastMove = _taskService.GetTaskStateHistory().Where(x => x.TaskId == lastMove.TaskId).OrderByDescending(x => x.Id).FirstOrDefault();
            
            var taskViewModel = new TaskViewModel
            {
                Id = lastMove.TaskId,
                StateId = lastMove.StateId
            };

            await _taskService.UpdateTaskAsync(taskViewModel, cancellationToken);
        }

        public async Task ReturnToPreviousState(int id, DateTime specificTime, CancellationToken cancellationToken)
        {
            var task = await _taskService.GetTaskAsync(id, cancellationToken);
            var specifiedState = _taskService.GetTaskStateHistory().FirstOrDefault(x => x.CreateDate < specificTime && specificTime < x.DeleteDate);
            if (specifiedState == null)
            {
                throw new Exception($"State not found in specified time within {specificTime.ToString("dd/MM/yyyy")}");
            }

            if (!task.CurrentFlow.States.Any(x => x.StateId == specifiedState.State.Id))
            {
                throw new Exception("Specified state does not exist in current flow.");
            }

            var taskViewModel = new TaskViewModel
            {
                Id = task.Id,
                StateId = specifiedState.State.Id
            };

            await _taskService.UpdateTaskAsync(taskViewModel, cancellationToken);
        }
    }
}
