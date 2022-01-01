using StateManagement.Data.Entities;
using Task = System.Threading.Tasks.Task;

namespace StateManagement.Business.Services.Base
{
    public interface IFlowService
    {
        Task CreateFlowAsync(Flow flow, CancellationToken cancellationToken);
        Task UpdateFlowAsync(Flow model, CancellationToken cancellationToken);
        IEnumerable<Flow> GetFlows();
        Task<Flow?> GetFlowAsync(int id, CancellationToken cancellationToken);
        Task DeleteFlowAsync(int id, CancellationToken cancellationToken);
    }
}
