

using GreenTunnel.Core.Entities;
using DAL.Repositories.Interfaces;
using GreenTunnel.Infrastructure;
using GreenTunnel.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class WorkplacesRepository : Repository<Workplace>, IWorkplaceRepository
    {
        public WorkplacesRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public async Task<Workplace> GetByIdAsync(int id)
        {
            return await _appContext.Workplaces.FindAsync(id);
        }
    }
}