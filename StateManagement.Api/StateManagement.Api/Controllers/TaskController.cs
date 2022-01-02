using Microsoft.AspNetCore.Mvc;
using StateManagement.Business.Handlers.Base;
using StateManagement.Business.Services.Base;
using StateManagement.Business.ViewModels;

namespace StateManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskStateHandler _taskStateHandler;
        private readonly ILogger<TaskController> _logger;

        public TaskController(
            ITaskService taskService,
            ITaskStateHandler taskStateHandler,
            ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _taskStateHandler = taskStateHandler;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Data.Entities.Task> GetTasks()
        {
            return _taskService.GetTasks();
        }

        [HttpGet("{id}")]
        public async Task<Data.Entities.Task?> GetTaskAsync(int id, CancellationToken cancellationToken)
        {
            return await _taskService.GetTaskAsync(id, cancellationToken);
        }

        [HttpPost]
        public async Task CreateTaskAsync(TaskViewModel task, CancellationToken cancellationToken)
        {
            await _taskService.CreateTaskAsync(task, cancellationToken);
        }

        [HttpPut]
        public async Task UpdateTaskAsync(TaskViewModel task, CancellationToken cancellationToken)
        {
            await _taskService.UpdateTaskAsync(task, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTaskAsync(int id, CancellationToken cancellationToken)
        {
            await _taskService.DeleteTaskAsync(id, cancellationToken);
        }

        [HttpPost("{id}/next")]
        public async Task MoveNextAsync(int id, CancellationToken cancellationToken)
        {
            await _taskStateHandler.MoveToNextState(id, cancellationToken);
        }

        [HttpPost("{id}/previous")]
        public async Task MovePreviousAsync(int id, CancellationToken cancellationToken)
        {
            await _taskStateHandler.MoveToPreviousState(id, cancellationToken);
        }

        [HttpPost("undo")]
        public async Task UndoAsync(CancellationToken cancellationToken)
        {
            await _taskStateHandler.UndoLastMove(cancellationToken);
        }
    }
}
