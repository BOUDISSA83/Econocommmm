using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlaces;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Queries;

public class GetWorkplacesListQuery : IRequest<List<GetWorkplacesListResponseModel>>
{
}