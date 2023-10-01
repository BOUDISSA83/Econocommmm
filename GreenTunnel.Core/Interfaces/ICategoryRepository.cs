using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Core.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> AddAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<PagedList<Category>> GetCategoryAsync(string? sortColumn, string? sortOrder, string? searchTerm, int page, int pageSize);
    }
}
