using AutoMapper;

using GreenTunnel.Application.Moulds.Queries;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace GreenTunnel.Application.Moulds.Handlers;

public class GetMouldsQueryHandler : IRequestHandler<GetAllMouldsQuery, List<MouldsViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IMouldsRepository _mouldsRepository;

    public GetMouldsQueryHandler(
        IMapper mapper,
        ILogger<GetMouldsQueryHandler> logger,
        IMouldsRepository mouldsRepository)
    {
        _mapper = mapper;
        _mouldsRepository = mouldsRepository;
    }

    public async Task<List<MouldsViewModel>> Handle(GetAllMouldsQuery request, CancellationToken cancellationToken)
    {
        var allMoulds = _mouldsRepository.GetAll();

        return _mapper.Map<List<MouldsViewModel>>(allMoulds);
    }
}
