using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;

namespace GreenTunnel.Core.Interfaces
{
    public interface ITestTypeRepository : IRepository<TestType>
    {

        Task<TestType> GetByIdAsync(int id);
        Task<TestType> AddAsync(TestType testType);
        Task<List<TestType>> GetAllTestTypes();
        Task<PagedList<TestType>> GetTestTypesAsync(string? sortColumn, string? sortOrder, string? searchTerm, int page, int pageSize);
    }
}
