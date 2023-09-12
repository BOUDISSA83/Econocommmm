using GreenTunnel.Infrastructure.ViewModels;

using MediatR;

namespace GreenTunnel.Application.Moulds.Queries;

public class GetAllMouldsQuery : IRequest<List<MouldsViewModel>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
