

using GreenTunnel.Core.Entities;

namespace GreenTunnel.Core.Interfaces;

public interface IMouldsRepository : IRepository<Moulds>
{
    Task<List<Moulds>> GetAllByWorkspaceId(int id);
}