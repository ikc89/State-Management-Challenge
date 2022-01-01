using Microsoft.AspNetCore.Mvc;
using StateManagement.Business.Services.Base;
using StateManagement.Data.Entities;
using Task = System.Threading.Tasks.Task;

namespace StateManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        private readonly ILogger<StateController> _logger;

        public StateController(
            IStateService stateService,
            ILogger<StateController> logger)
        {
            _stateService = stateService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<State> GetStatesAsync(CancellationToken cancellationToken)
        {
            return _stateService.GetStates();
        }

        [HttpGet("{id}")]
        public async Task<State?> GetStateAsync(int id, CancellationToken cancellationToken)
        {
            return await _stateService.GetStateAsync(id, cancellationToken);
        }

        [HttpPost]
        public async Task CreateStateAsync(State state, CancellationToken cancellationToken)
        {
            await _stateService.CreateStateAsync(state, cancellationToken);
        }

        [HttpPut]
        public async Task UpdateStateAsync(State state, CancellationToken cancellationToken)
        {
            await _stateService.UpdateStateAsync(state, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task DeleteStateAsync(int id, CancellationToken cancellationToken)
        {
            await _stateService.DeleteStateAsync(id, cancellationToken);
        }
    }
}
