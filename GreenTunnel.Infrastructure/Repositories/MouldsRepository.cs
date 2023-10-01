

using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenTunnel.Infrastructure.Repositories;

public class MouldsRepository : Repository<Moulds>, IMouldsRepository
{

    public MouldsRepository(ApplicationDbContext context) : base(context)
    {
        _appContext = context;
    }


    private ApplicationDbContext _appContext;
    public async Task<List<Moulds>> GetAllByWorkspaceId(int id)
    {
        return await _appContext.Moulds.Where(m => m.WorkspaceId == id).ToListAsync();
    }
}