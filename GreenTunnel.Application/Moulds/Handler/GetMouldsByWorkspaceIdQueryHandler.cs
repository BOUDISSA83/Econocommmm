using AutoMapper;
using GreenTunnel.Application.Moulds.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace GreenTunnel.Application.User.Handlers;

public class GetMouldsByWorkspaceIdQueryHandler : IRequestHandler<GetMouldsByWorkspaceIdQuery, PagedList<MouldsViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IMouldsRepository _mouldsRepository;
    public GetMouldsByWorkspaceIdQueryHandler(IAuthorizationService authorizationService,
        IMapper mapper,
        ILogger<GetMouldsByWorkspaceIdQueryHandler> logger,
        IMouldsRepository mouldsRepository)
    {
        _mapper = mapper;
        _mouldsRepository = mouldsRepository;
    }

    public async Task<PagedList<MouldsViewModel>> Handle(GetMouldsByWorkspaceIdQuery request, CancellationToken cancellationToken)
    {
        return await GetMouldsByWorkspaceId(request.Id, request);
    }
    private async Task<PagedList<MouldsViewModel>> GetMouldsByWorkspaceId(int id, GetMouldsByWorkspaceIdQuery request)
    {

        var moulds = await _mouldsRepository.GetAllByWorkspaceId(id);
        var mouldsViewModels = _mapper.Map<List<MouldsViewModel>>(moulds);
        var pagedList = new PagedList<MouldsViewModel>(
            mouldsViewModels,
            request.PageNumber,
            request.PageSize,
            mouldsViewModels.Count);

        return pagedList;
    }
}