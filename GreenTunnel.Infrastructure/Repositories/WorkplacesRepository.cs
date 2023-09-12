﻿using Microsoft.EntityFrameworkCore;

using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.Helpers;

using System.Linq.Expressions;


namespace GreenTunnel.Infrastructure.Repositories;

public class WorkplacesRepository : Repository<Workplace>, IWorkplaceRepository
{
    public WorkplacesRepository(ApplicationDbContext context) : base(context)
    { }

    private ApplicationDbContext _appContext;

    public async Task<Workplace> AddAsync(Workplace workplace)
    {
        _appContext.Workplaces.Add(workplace);
        await _appContext.SaveChangesAsync();
        return workplace;
    }

    public async Task<List<Workplace>> GetAllWorkplaces()
    {
        IQueryable<Workplace> workplaces = _appContext.Workplaces
            .AsSingleQuery()
            .OrderBy(r => r.CreatedDate);
        var workplacesList = await workplaces.ToListAsync();

        return workplacesList;
    }

    public async Task<Workplace> GetByIdAsync(int id)
    {
        return await _appContext.Workplaces.FindAsync(id);
    }

    private static Expression<Func<Workplace, object>> GetSortProperty(string sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "name" => workplace => workplace.Name,
            _ => workplace => workplace.Id,
        };
    }

    public async Task<PagedList<Workplace>> GetWorkplacesAsync(string sortColumn, string sortOrder, string searchTerm, int? factoryId, int page, int pageSize)
    {
        IQueryable<Workplace> workplacesQuery = _appContext.Workplaces;

        if (factoryId > 0)
        {
            workplacesQuery = _appContext.Workplaces.Where(m => m.FactoryId == factoryId)
            .Include(r => r.Workspaces)
            .AsSingleQuery()
            .OrderBy(r => r.CreatedDate);
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                workplacesQuery = workplacesQuery.Where(p => p.Name.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                workplacesQuery = workplacesQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                workplacesQuery = workplacesQuery.OrderBy(GetSortProperty(sortColumn));
            }
            workplacesQuery = workplacesQuery.Include(r => r.Workspaces)
           .AsSingleQuery()
           .OrderBy(r => r.CreatedDate);
        }

        var workplacesListResponsesQuery = workplacesQuery;
        var workplacesResult = await PagedList<Workplace>.CreateAsync(workplacesListResponsesQuery, page, pageSize);

        return workplacesResult;
    }
}