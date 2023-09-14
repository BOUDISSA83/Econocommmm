using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;

namespace GreenTunnel.Application.Moulds.Queries
{
    public class GetMouldsByWorkspaceIdQuery : IRequest<PagedList<MouldsViewModel>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
