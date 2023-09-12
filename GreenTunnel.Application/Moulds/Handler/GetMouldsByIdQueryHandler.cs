using AutoMapper;

using GreenTunnel.Application.Moulds.Queries;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels;

using MediatR;

using Microsoft.Extensions.Logging;

namespace GreenTunnel.Application.User.Handlers;

public class GetMouldsByIdQueryHandler : IRequestHandler<GetMouldsByIdQuery, MouldsViewModel>
{
    private readonly IMapper _mapper;
    private readonly IMouldsRepository _mouldsRepository;

    public GetMouldsByIdQueryHandler(
        IMapper mapper,
        ILogger<GetMouldsByIdQueryHandler> logger,
        IMouldsRepository mouldsRepository)
    {
        _mapper = mapper;
        _mouldsRepository = mouldsRepository;
    }

    public async Task<MouldsViewModel> Handle(GetMouldsByIdQuery request, CancellationToken cancellationToken)
    {
        return await GetMouldsById(request.Id);
    }
    private async Task<MouldsViewModel> GetMouldsById(int id)
    {

        var moulds = _mouldsRepository.Get(id);
        return _mapper.Map<MouldsViewModel>(moulds);
    }
}
