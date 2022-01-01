using StateManagement.Data.Context;
using StateManagement.Data.Entities;
using StateManagement.Data.Repositories.Base;
using StateManagement.Data.Repositories.Interfaces;

namespace StateManagement.Data.Repositories
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(StateManagementContext context)
            : base(context)
        {

        }
    }
}
