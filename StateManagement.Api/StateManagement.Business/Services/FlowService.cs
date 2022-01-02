using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StateManagement.Api.ViewModels;
using StateManagement.Business.Services.Base;
using StateManagement.Business.ViewModels;
using StateManagement.Data.Entities;
using StateManagement.Data.Repositories.Base.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace StateManagement.Business.Services
{
    public class FlowService : IFlowService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FlowService> _logger;

        public FlowService(
            IUnitOfWork unitOfWork,
            ILogger<FlowService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task CreateFlowAsync(Flow flow, CancellationToken cancellationToken)
        {
            await _unitOfWork.Flows.AddAsync(flow, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task UpdateFlowAsync(Flow model, CancellationToken cancellationToken)
        {
            var flow = await _unitOfWork.Flows.SingleOrDefaultAsync(x => x.Id == model.Id && x.DeleteDate == null, cancellationToken);
            if (flow == null)
            {
                throw new Exception($"Flow is not found or may be deleted with id: {model.Id}");
            }

            _unitOfWork.Flows.Update(flow);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public IEnumerable<Flow> GetFlows()
        {
            return _unitOfWork.Flows.GetAllAsQuery().Where(x => x.DeleteDate == null).ToList();
        }

        public async Task<Flow?> GetFlowAsync(int id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Flows.GetByIdAsync(id, cancellationToken);
        }

        public async Task DeleteFlowAsync(int id, CancellationToken cancellationToken)
        {
            var flow = await _unitOfWork.Flows.SingleOrDefaultAsync(x => x.Id == id && x.DeleteDate == null, cancellationToken);
            if (flow == null)
            {
                throw new Exception($"Flow is not found or may be deleted with id: {id}");
            }

            flow.DeleteDate = DateTime.UtcNow;

            _unitOfWork.Flows.Update(flow);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task CreateFlowStateAsync(FlowStateViewModel model, CancellationToken cancellationToken)
        {
            var flow = await _unitOfWork.Flows.SingleOrDefaultAsync(x => x.Id == model.FlowId && x.DeleteDate == null, cancellationToken);
            if (flow == null)
            {
                throw new Exception($"Flow is not found or may be deleted with id: {model.FlowId}");
            }

            var state = await _unitOfWork.States.SingleOrDefaultAsync(x => x.Id == model.StateId && x.DeleteDate == null, cancellationToken);
            if (state == null)
            {
                throw new Exception($"State is not found or may be deleted with id: {model.FlowId}");
            }

            var flowState = new FlowState
            {
                FlowId = model.FlowId,
                StateId = model.StateId,
                Order = model.Order
            };
            await _unitOfWork.FlowStates.AddAsync(flowState, cancellationToken);

            flow.States.ToList().Add(flowState);
            _unitOfWork.Flows.Update(flow);

            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task<IEnumerable<FlowStateTaskViewModel>> GetFlowStatesByFlowIdAsync(int id, CancellationToken cancellationToken)
        {
            var flow = await _unitOfWork.Flows.SingleOrDefaultAsync(x => x.Id == id && x.DeleteDate == null, cancellationToken);
            if (flow == null)
            {
                throw new Exception($"Flow is not found or may be deleted with id: {id}");
            }

            return _unitOfWork.FlowStates.GetAllAsQuery()
                .Where(x => x.FlowId == id && x.DeleteDate == null).Include(x => x.State)
                .Select(x => new FlowStateTaskViewModel
                {
                    Id = x.Id,
                    State = x.State,
                    Order = x.Order,
                    Tasks = _unitOfWork.Tasks.GetAllAsQuery().Where(y => y.StateId == x.StateId).ToList()
                }).ToList();
        }
    }
}
