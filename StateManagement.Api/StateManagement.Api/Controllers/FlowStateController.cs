using Microsoft.AspNetCore.Mvc;
using StateManagement.Api.ViewModels;
using StateManagement.Business.Services.Base;
using StateManagement.Business.ViewModels;
using StateManagement.Data.Entities;
using Task = System.Threading.Tasks.Task;

namespace StateManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowStateController : ControllerBase
    {
        private readonly IFlowService _flowService;
        private readonly ILogger<FlowController> _logger;

        public FlowStateController(
            IFlowService flowService,
            ILogger<FlowController> logger)
        {
            _flowService = flowService;
            _logger = logger;
        }

        [HttpPost]
        public async Task CreateFlowStateAsync(FlowStateViewModel flowState, CancellationToken cancellationToken)
        {
            await _flowService.CreateFlowStateAsync(flowState, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<FlowStateTaskViewModel>> GetFlowStatesByFlowIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _flowService.GetFlowStatesByFlowIdAsync(id, cancellationToken);
        }
    }
}
