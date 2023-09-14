
using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace GreenTunnel.Core.Repositories.Interfaces
{
    public interface IWorkSpaceRepository : IRepository<Workspace>
    {
        Task<Workspace> GetByIdAsync(int id);
        Task<Workspace> GetByIdDetailsAsync(int id);
        Task<Workspace> AddAsync(Workspace workspace);
        Task<PagedList<Workspace>> GetWorkSpacesAsync(string? sortColumn, string? sortOrder, string? searchTerm, int? workplaceId,int page, int pageSize);
    }
}
