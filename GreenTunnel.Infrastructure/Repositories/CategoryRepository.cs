using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public CategoryRepository(ApplicationDbContext context):base(context) { }

        public async Task<Category> AddAsync(Category category)
        {
            _appContext.Categories.Add(category);
            await _appContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            IQueryable<Category> categories = _appContext.Categories
                .AsSingleQuery()
                .OrderBy(r => r.CreatedDate);
            var categoriesList = await categories.ToListAsync();

            return categoriesList;
        }
        private static Expression<Func<Category, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => category => category.Name,
                _ => category => category.Id,
            };
        }
        public async Task<PagedList<Category>> GetCategoryAsync(string sortColumn, string sortOrder, string searchTerm, int page, int pageSize)
        {
            IQueryable<Category> categoriesQuery = _appContext.Categories;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                categoriesQuery = categoriesQuery.Where(p => p.Name.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                categoriesQuery = categoriesQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                categoriesQuery = categoriesQuery.OrderBy(GetSortProperty(sortColumn));
            }

            var categories = categoriesQuery
               .AsSingleQuery()
               .OrderBy(r => r.CreatedDate);


            var categoriesListResponsesQuery = categories;
            var categoriesResult = await PagedList<Category>.CreateAsync(categoriesListResponsesQuery, page, pageSize);

            return categoriesResult;
        }
    }
}
