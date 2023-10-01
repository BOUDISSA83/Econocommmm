

using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using GreenTunnel.Core.Interfaces;

namespace GreenTunnel.Infrastructure.Repositories;

public class FactoryRepository : Repository<Factory>, IFactoryRepository
{

    public FactoryRepository(ApplicationDbContext context) : base(context)
    { }

    public IEnumerable<Factory> GetTopActiveCustomers(int count)
    {
        throw new NotImplementedException();
    }



    public async Task<Factory> AddAsync(Factory factory)
    {
        _appContext.Factories.Add(factory);
        await _appContext.SaveChangesAsync();
        return factory;
    }

    public async Task<List<Factory>> GetAllFactories()
    {
        IQueryable<Factory> factories = _appContext.Factories
            .AsSingleQuery()
            .OrderBy(r => r.CreatedDate);
        var factoriesList = await factories.ToListAsync();

        return factoriesList;
    }
    public async Task<PagedList<Factory>> GetFactoriesAsync(string? sortColumn, string? sortOrder, string? searchTerm, int page, int pageSize)
    {
        IQueryable<Factory> factoriesQuery = _appContext.Factories;
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            factoriesQuery = factoriesQuery.Where(p => p.Name.Contains(searchTerm));
        }

        if (sortOrder?.ToLower() == "desc")
        {
            factoriesQuery = factoriesQuery.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            factoriesQuery = factoriesQuery.OrderBy(GetSortProperty(sortColumn));
        }

        var factories = factoriesQuery.Include(r => r.Workplaces)
            .AsSingleQuery()
            .OrderBy(r => r.CreatedDate);


        var factoriesListResponsesQuery = factories;
        var factoriesResult = await PagedList<Factory>.CreateAsync(factoriesListResponsesQuery, page, pageSize);

        return factoriesResult;
    }

    private static Expression<Func<Factory, object>> GetSortProperty(string sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "name" => factory => factory.Name,
            _ => factory => factory.Id,
        };
    }

    private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
}