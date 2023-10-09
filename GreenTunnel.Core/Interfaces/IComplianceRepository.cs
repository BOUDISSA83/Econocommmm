using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;

namespace GreenTunnel.Core.Interfaces
{
    public interface IComplianceRepository : IRepository<Compliance>
    {
        Task<Compliance> GetByIdAsync(int id);
        Task<Compliance> AddAsync(Compliance compliance);
        Task<List<Compliance>> GetAllCompliances();
        Task<PagedList<Compliance>> GetTCompliancesAsync(string? sortColumn, string? sortOrder, string? searchTerm, int page, int pageSize);
    }
}
