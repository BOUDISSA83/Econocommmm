using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;

namespace GreenTunnel.Core.Interfaces
{
    public interface ITestRepository : IRepository<Test>
    {

        Task<Test> AddAsync(Test test);

        Task<List<Test>> GetAllTests();

        Task<Test> GetByIdAsync(int id);
        Task<Test> GetByIdDetailsAsync(int id);
    //    Task GetByIdDetailsAsync(object testId);
        Task<PagedList<Test>> GetTestsAsync(string? sortColumn, string? sortOrder, string? searchTerm, int page, int pageSize);

    }
}
