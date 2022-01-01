using Microsoft.Extensions.Logging;
using StateManagement.Business.Services.Base;
using StateManagement.Data.Entities;
using StateManagement.Data.Repositories.Base.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace StateManagement.Business.Services
{
    public class StateService : IStateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StateService> _logger;

        public StateService(
            IUnitOfWork unitOfWork,
            ILogger<StateService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task CreateStateAsync(State state, CancellationToken cancellationToken)
        {
            await _unitOfWork.States.AddAsync(state, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task UpdateStateAsync(State model, CancellationToken cancellationToken)
        {
            var state = await _unitOfWork.States.SingleOrDefaultAsync(x => x.Id == model.Id && x.DeleteDate == null, cancellationToken);
            if (state == null)
            {
                throw new Exception($"State is not found or may be deleted with id: {model.Id}");
            }

            _unitOfWork.States.Update(state);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public IEnumerable<State> GetStates()
        {
            return _unitOfWork.States.GetAllAsQuery().Where(x => x.DeleteDate == null).ToList();
        }

        public async Task<State?> GetStateAsync(int id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.States.GetByIdAsync(id, cancellationToken);
        }

        public async Task DeleteStateAsync(int id, CancellationToken cancellationToken)
        {
            var state = await _unitOfWork.States.SingleOrDefaultAsync(x => x.Id == id && x.DeleteDate == null, cancellationToken);
            if (state == null)
            {
                throw new Exception($"State is not found or may be deleted with id: {id}");
            }

            state.DeleteDate = DateTime.UtcNow;

            _unitOfWork.States.Update(state);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
