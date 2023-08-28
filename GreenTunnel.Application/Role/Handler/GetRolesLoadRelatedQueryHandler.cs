using AutoMapper;
using GreenTunnel.Application.Role.Queries;
using GreenTunnel.Application.User.Queries;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Role.Handlers
{

    public class GetRolesLoadRelatedQueryHandler : IRequestHandler<GetRolesLoadRelatedQuery, List<ApplicationRole>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<GetRolesLoadRelatedQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;
        public GetRolesLoadRelatedQueryHandler(IAuthorizationService authorizationService,
            IMapper mapper,
            ILogger<GetRolesLoadRelatedQueryHandler> logger,
            IAccountManager accountManager)
        {
            _authorizationService = authorizationService;
            _logger = logger;
            _mapper = mapper;
            _accountManager = accountManager;
        }
        public async Task<List<ApplicationRole>> Handle(GetRolesLoadRelatedQuery request, CancellationToken cancellationToken)
        {
          return  await _accountManager.GetRolesLoadRelatedAsync(request.Page, request.PageSize);
        }
    }
}
