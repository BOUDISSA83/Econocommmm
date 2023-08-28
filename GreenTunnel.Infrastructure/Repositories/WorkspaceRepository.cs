

using GreenTunnel.Core.Entities;
using DAL.Repositories.Interfaces;
using GreenTunnel.Infrastructure;
using GreenTunnel.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class WorkspaceRepository : Repository<Product>, IWorkSpaceRepository
    {
        public WorkspaceRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
