﻿using StateManagement.Data.Context;
using StateManagement.Data.Entities;
using StateManagement.Data.Repositories.Base;
using StateManagement.Data.Repositories.Interfaces;

namespace StateManagement.Data.Repositories
{
    public class FlowRepository : Repository<Flow>, IFlowRepository
    {
        public FlowRepository(StateManagementContext context)
            : base(context)
        {

        }
    }
}
