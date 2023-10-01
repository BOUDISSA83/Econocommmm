using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Core.Interfaces
{
    public interface IDescriptionRepository:IRepository<Description>
    {
        Task<Description> AddAsync(Description description);
        Task<List<Description>> GetAllAsync();
        Task<PagedList<Description>> GetAllDescriptionsAsync(string? sortColumn, string? sortOrder, string? searchTerm, int page, int pageSize);
    }
}
