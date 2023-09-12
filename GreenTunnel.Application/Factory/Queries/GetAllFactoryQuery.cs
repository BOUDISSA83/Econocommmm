using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;

using MediatR;

namespace GreenTunnel.Application.Factory.Queries;

public class GetAllFactoryQuery : IRequest<PagedList<FactoryViewModel>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; }
    public string? SortOrder { get; set; }
}
