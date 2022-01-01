using Microsoft.AspNetCore.Mvc;
using StateManagement.Business.Services.Base;

namespace StateManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(
            ITaskService taskService,
            ILogger<TaskController> logger)
        {
            _taskService = taskService;
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
        public async Task CreateTaskAsync(Data.Entities.Task task, CancellationToken cancellationToken)
        {
            await _taskService.CreateTaskAsync(task, cancellationToken);
        }

        [HttpPut]
        public async Task UpdateTaskAsync(Data.Entities.Task task, CancellationToken cancellationToken)
        {
            await _taskService.UpdateTaskAsync(task, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTaskAsync(int id, CancellationToken cancellationToken)
        {
            await _taskService.DeleteTaskAsync(id, cancellationToken);
        }
    }
}
