using AutoMapper;
using DAL.Core;
using GreenTunnel.Application.CQRS.Queries;
using GreenTunnel.Application.Moulds.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.Authorization;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.User.Handlers
{
    public class GetMouldsByIdQueryHandler : IRequestHandler<GetMouldsByIdQuery, MouldsViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IMouldsRepository _mouldsRepository;
        public GetMouldsByIdQueryHandler(IAuthorizationService authorizationService,
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

}
