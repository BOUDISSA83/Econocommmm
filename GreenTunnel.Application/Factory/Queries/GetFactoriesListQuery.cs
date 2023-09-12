using GreenTunnel.Infrastructure.ViewModels.Response.Factory;

using MediatR;

namespace GreenTunnel.Application.Factory.Queries;

public class GetFactoriesListQuery : IRequest<List<GetFacoriesListResponseModel>>
{
}
