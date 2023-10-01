using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;

namespace GreenTunnel.Application.Factories.Queries;

public class GetFactoriesListQuery : IRequest<List<GetFacoriesListResponseModel>>
{
}