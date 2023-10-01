using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Queries;

public class GetAllWorkplaceQuery : IRequest<PagedList<WorkplaceViewModel>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; }
    public string? SortOrder { get; set; }
    public int? FactoryId { get; set; }
}