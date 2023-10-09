using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class ComplianceRepository : Repository<Compliance>, IComplianceRepository
    {
        public ComplianceRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public async Task<Compliance> AddAsync(Compliance Compliance)
        {
            _appContext.Compliances.Add(Compliance);
            await _appContext.SaveChangesAsync();
            return Compliance;
        }

        public Task<List<Compliance>> GetAllCompliances()
        {
            throw new NotImplementedException();
        }

        public async Task<Compliance> GetByIdAsync(int id)
        {
            return await _appContext.Compliances.FindAsync(id);
        }

        public Task<PagedList<Compliance>> GetTCompliancesAsync(string sortColumn, string sortOrder, string searchTerm, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
