using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;

using Microsoft.EntityFrameworkCore;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class TestTypeRepository : Repository<TestType>, ITestTypeRepository
    {

        public TestTypeRepository(ApplicationDbContext context) : base(context)
        { }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public async Task<TestType> AddAsync(TestType testtype)
        {
            _appContext.TestTypes.Add(testtype);
            await _appContext.SaveChangesAsync();
            return testtype;
        }

        public async Task<List<TestType>> GetAllTestTypes()
        {
            IQueryable<TestType> testTypes = _appContext.TestTypes
                .AsSingleQuery()
                .OrderBy(r => r.CreatedDate);
            var testTypesList = await _appContext.TestTypes.ToListAsync();
            return testTypesList;
        }

        public async Task<TestType> GetByIdAsync(int id)
        {
            return await _appContext.TestTypes.FindAsync(id);
        }

        public async Task<PagedList<TestType>> GetTestTypesAsync(string sortColumn, string sortOrder, string searchTerm, int page, int pageSize)
        {
            IQueryable<TestType> testTypesQuery = _appContext.TestTypes;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                testTypesQuery = testTypesQuery.Where(p => p.Name.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                testTypesQuery = testTypesQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                testTypesQuery = testTypesQuery.OrderBy(GetSortProperty(sortColumn));
            }

            var tests = testTypesQuery
               .AsSingleQuery()
               .OrderBy(r => r.CreatedDate);


            var testTypessListResponsesQuery = tests;
            var testsResult = await PagedList<TestType>.CreateAsync(testTypessListResponsesQuery, page, pageSize);

            return testsResult;
        }




        private static Expression<Func<TestType, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => testType => testType.Name,
                _ => testType => testType.Id,
            };
        }
    }
}
