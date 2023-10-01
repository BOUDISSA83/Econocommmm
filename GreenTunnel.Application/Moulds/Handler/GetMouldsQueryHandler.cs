using AutoMapper;
using GreenTunnel.Application.Moulds.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace GreenTunnel.Application.Moulds.Handlers;

public class GetMouldsQueryHandler : IRequestHandler<GetAllMouldsQuery, PagedList<MouldsViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IMouldsRepository _mouldsRepository;

    public GetMouldsQueryHandler(IAuthorizationService authorizationService,
        IMapper mapper,
        ILogger<GetMouldsQueryHandler> logger,
        IMouldsRepository mouldsRepository)
    {
        _mapper = mapper;
        _mouldsRepository = mouldsRepository;
    }
    public async Task<PagedList<MouldsViewModel>> Handle(GetAllMouldsQuery request, CancellationToken cancellationToken)
    {
        var allMoulds = _mouldsRepository.GetAll();
        if (!(request.SearchValue == "" || request.SearchValue == "null"))
        {
            allMoulds = allMoulds.Where(x => x.Name.ToLower().Contains(request.SearchValue.ToLower()) || x.Type.ToLower().Contains(request.SearchValue.ToLower())).ToList();
        }
        var mouldsViewModels = _mapper.Map<List<MouldsViewModel>>(allMoulds);
        var pagedList = new PagedList<MouldsViewModel>(
            mouldsViewModels,
            request.PageNumber,
            request.PageSize,
            mouldsViewModels.Count);

        return pagedList;
    }
}