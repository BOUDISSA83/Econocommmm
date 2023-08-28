using AutoMapper;
using GreenTunnel.Application.Role.Queries;
using GreenTunnel.Application.User.Handlers;
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

namespace GreenTunnel.Application.Role.Handler
{
    public class GetRoleLoadRelatedQueryHandler : IRequestHandler<GetRoleLoadRelatedQuery, ApplicationRole>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<GetRoleLoadRelatedQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;

        public GetRoleLoadRelatedQueryHandler(IAuthorizationService authorizationService,
            IMapper mapper,
            ILogger<GetRoleLoadRelatedQueryHandler> logger,
            IAccountManager accountManager)
        {
            _authorizationService = authorizationService;
            _logger = logger;
            _mapper = mapper;
            _accountManager = accountManager;
        }
        public async Task<ApplicationRole> Handle(GetRoleLoadRelatedQuery request, CancellationToken cancellationToken)
        {
            return await _accountManager.GetRoleLoadRelatedAsync(request.RoleName);
        }
    }
}
