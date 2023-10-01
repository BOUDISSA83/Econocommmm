using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class DescriptionRepository :Repository<Description>, IDescriptionRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public DescriptionRepository(ApplicationDbContext context):base(context)
        {
            
        }
        public async Task<Description> AddAsync(Description description)
        {
            _appContext.Descriptions.Add(description);
            await _appContext.SaveChangesAsync();
            return description;
        }

        public async Task<List<Description>> GetAllAsync()
        {
            IQueryable<Description> descriptions = _appContext.Descriptions
               .AsSingleQuery()
               .OrderBy(r => r.CreatedDate);
            var descriptionsList = await descriptions.ToListAsync();

            return descriptionsList;
        }
        private static Expression<Func<Description, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => description => description.Name,
                _ => description => description.Id,
            };
        }
        public async Task<PagedList<Description>> GetAllDescriptionsAsync(string? sortColumn, string? sortOrder, string? searchTerm, int page, int pageSize)
        {
            IQueryable<Description> descriptionsQuery = _appContext.Descriptions;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                descriptionsQuery = descriptionsQuery.Where(p => p.Name.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                descriptionsQuery = descriptionsQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                descriptionsQuery = descriptionsQuery.OrderBy(GetSortProperty(sortColumn));
            }

            var factories = descriptionsQuery
               .AsSingleQuery()
               .OrderBy(r => r.CreatedDate);


            var factoriesListResponsesQuery = factories;
            var factoriesResult = await PagedList<Description>.CreateAsync(factoriesListResponsesQuery, page, pageSize);

            return factoriesResult;
        }

    }
}
