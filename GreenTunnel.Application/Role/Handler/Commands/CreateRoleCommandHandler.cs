using AutoMapper;
using GreenTunnel.Application.Role.Commands.CreateRole;
using GreenTunnel.Application.User.Handlers.Commands;
using GreenTunnel.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Role.Handler.Commands
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, (bool Succeeded, string[] Errors)>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<CreateRoleCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;
        public CreateRoleCommandHandler(IAuthorizationService authorizationService,
            IMapper mapper,
            ILogger<CreateRoleCommandHandler> logger,
            IAccountManager accountManager)
        {
            _authorizationService = authorizationService;
            _logger = logger;
            _mapper = mapper;
            _accountManager = accountManager;
        }
        public async Task<(bool Succeeded, string[] Errors)> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _accountManager.CreateRoleAsync(request.Role, request.RoleView.Permissions?.Select(p => p.Value).ToArray());
        }
    }
}
