using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;

namespace GreenTunnel.Application.Moulds.Queries;

public class GetAllMouldsQuery : IRequest<PagedList<MouldsViewModel>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchValue { get; set; }
}