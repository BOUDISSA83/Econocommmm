

using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure;
using GreenTunnel.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using GreenTunnel.Repositories.Interfaces;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class WorkplaceRepository : Repository<Workplace>, IWorkplaceRepository
    {
        public WorkplaceRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public async Task<Workplace> GetByIdAsync(int id)
        {
            return await _appContext.Workplaces.FindAsync(id);
        }
    }
}