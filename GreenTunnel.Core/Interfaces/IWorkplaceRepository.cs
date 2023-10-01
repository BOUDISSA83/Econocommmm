

using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;

namespace GreenTunnel.Core.Interfaces;

public interface IWorkplaceRepository : IRepository<Workplace>
{
    Task<Workplace> GetByIdAsync(int id);
    Task<Workplace> GetByIdDetailsAsync(int id);

    Task<Workplace> AddAsync(Workplace factory);
    Task<List<Workplace>> GetAllWorkplaces();
    Task<PagedList<Workplace>> GetWorkplacesAsync(string? sortColumn, string? sortOrder, string? searchTerm, int? factoryId, int page, int pageSize);

}