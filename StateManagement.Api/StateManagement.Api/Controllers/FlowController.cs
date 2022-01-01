using Microsoft.AspNetCore.Mvc;
using StateManagement.Business.Services.Base;
using StateManagement.Data.Entities;
using Task = System.Threading.Tasks.Task;

namespace StateManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowController : ControllerBase
    {
        private readonly IFlowService _flowService;
        private readonly ILogger<FlowController> _logger;

        public FlowController(
            IFlowService flowService,
            ILogger<FlowController> logger)
        {
            _flowService = flowService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Flow> GetFlows()
        {
            return _flowService.GetFlows();
        }

        [HttpGet("{id}")]
        public async Task<Flow?> GetFlowAsync(int id, CancellationToken cancellationToken)
        {
            return await _flowService.GetFlowAsync(id, cancellationToken);
        }

        [HttpPost]
        public async Task CreateFlowAsync(Flow flow, CancellationToken cancellationToken)
        {
            await _flowService.CreateFlowAsync(flow, cancellationToken);
        }

        [HttpPut]
        public async Task UpdateFlowAsync(Flow flow, CancellationToken cancellationToken)
        {
            await _flowService.UpdateFlowAsync(flow, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task DeleteFlowAsync(int id, CancellationToken cancellationToken)
        {
            await _flowService.DeleteFlowAsync(id, cancellationToken);
        }
    }
}
