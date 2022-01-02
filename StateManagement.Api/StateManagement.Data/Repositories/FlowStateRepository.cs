using StateManagement.Data.Context;
using StateManagement.Data.Entities;
using StateManagement.Data.Repositories.Base;
using StateManagement.Data.Repositories.Interfaces;

namespace StateManagement.Data.Repositories
{
    public class FlowStateRepository : Repository<FlowState>, IFlowStateRepository
    {
        public FlowStateRepository(StateManagementContext context)
            : base(context)
        {
        }
    }
}
