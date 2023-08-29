

using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure;
using GreenTunnel.Infrastructure.Repositories;
using GreenTunnel.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class WorkspaceRepository : Repository<Workspace>, IWorkspaceRepository
    {
        public WorkspaceRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
