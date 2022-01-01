using StateManagement.Data.Entities;
using Task = System.Threading.Tasks.Task;

namespace StateManagement.Business.Services.Base
{
    public interface IStateService
    {
        Task CreateStateAsync(State state, CancellationToken cancellationToken);
        Task UpdateStateAsync(State model, CancellationToken cancellationToken);
        IEnumerable<State> GetStates();
        Task<State?> GetStateAsync(int id, CancellationToken cancellationToken);
        Task DeleteStateAsync(int id, CancellationToken cancellationToken);
    }
}
