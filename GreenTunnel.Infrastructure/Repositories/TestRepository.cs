

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

using static System.Net.Mime.MediaTypeNames;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class TestRepository  : Repository<Test>, ITestRepository
    {
        public TestRepository(ApplicationDbContext context) : base(context)
        { }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public async Task<Test> AddAsync(Test test)
        {
            _appContext.Tests.Add(test);
            await _appContext.SaveChangesAsync();
            return test;
        }

        public async Task<List<Test>> GetAllTests()
        {
            IQueryable<Test> tests = _appContext.Tests
                .AsSingleQuery()
                .OrderBy(r => r.CreatedDate);
            var testsList = await _appContext.Tests.ToListAsync();
            return testsList;
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            return await _appContext.Tests.FindAsync(id);
        }

        public async Task<PagedList<Test>> GetTestsAsync(string sortColumn, string sortOrder, string searchTerm, int page, int pageSize)
        {
            IQueryable<Test> testsQuery = _appContext.Tests;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                testsQuery = testsQuery.Where(p => p.Name.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                testsQuery = testsQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                testsQuery = testsQuery.OrderBy(GetSortProperty(sortColumn));
            }

            var tests = testsQuery.Include(r => r.TestType )//.Include( p=> p.Product)
               .AsSingleQuery()
               .OrderBy(r => r.CreatedDate);


            var testsListResponsesQuery = tests;
            var testsResult = await PagedList<Test>.CreateAsync(testsListResponsesQuery, page, pageSize);

            return testsResult;
        }
        public async Task<Test> GetByIdDetailsAsync(int id)
        {
            return await _appContext.Tests
                .Include(w => w.TestType)
                .FirstOrDefaultAsync(w => w.Id == id);
        }
        private static Expression<Func<Test, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => test => test.Name,
                _ => test => test.Id,
            };
        }
    }
}
