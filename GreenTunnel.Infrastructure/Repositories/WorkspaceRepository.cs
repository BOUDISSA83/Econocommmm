

using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class WorkspaceRepository : Repository<Workspace>, IWorkSpaceRepository
    {
        public WorkspaceRepository(ApplicationDbContext context) : base(context)
        { }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;


        public async Task<Workspace> AddAsync(Workspace workspace)
        {
            _appContext.Workspaces.Add(workspace);
            await _appContext.SaveChangesAsync();
            return workspace;
        }


        public async Task<Workspace> GetByIdAsync(int id)
        {
            return await _appContext.Workspaces.FindAsync(id);
        }

        public async Task<PagedList<Workspace>> GetWorkSpacesAsync(string? sortColumn, string? sortOrder, string? searchTerm, int? workplaceId, int page, int pageSize)
        {
            IQueryable<Workspace> workspacesQuery = _appContext.Workspaces;

            if (workplaceId > 0)
            {
                workspacesQuery = _appContext.Workspaces.Where(m => m.WorkplaceId == workplaceId)
                .AsSingleQuery()
                .OrderBy(r => r.CreatedDate);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    workspacesQuery = workspacesQuery.Where(p => p.Name.Contains(searchTerm));
                }

                if (sortOrder?.ToLower() == "desc")
                {
                    workspacesQuery = workspacesQuery.OrderByDescending(GetSortProperty(sortColumn));
                }
                else
                {
                    workspacesQuery = workspacesQuery.OrderBy(GetSortProperty(sortColumn));
                }
                workspacesQuery = workspacesQuery.Include(m=>m.Workplace)
               .AsSingleQuery()
               .OrderBy(r => r.CreatedDate);
            }
            var workspacesListResponsesQuery = workspacesQuery;
            var workspaceResult = await PagedList<Workspace>.CreateAsync(workspacesListResponsesQuery, page, pageSize);

            return workspaceResult;
        }
        private static Expression<Func<Workspace, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => workspace => workspace.Name,
                _ => workspace => workspace.Id,
            };
        }

        public async Task<Workspace> GetByIdDetailsAsync(int id)
        {
            return await _appContext.Workspaces
               .Include(w => w.Workplace)
               .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
