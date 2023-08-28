using AutoMapper;
using GreenTunnel.Application.User.Queries;
using GreenTunnel.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.User.Handlers
{
    public class CheckPasswordQueryHandler : IRequestHandler<CheckPasswordQuery, bool>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<CheckPasswordQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;

        public CheckPasswordQueryHandler(IAuthorizationService authorizationService,
            IMapper mapper,
            ILogger<CheckPasswordQueryHandler> logger,
            IAccountManager accountManager)
        {
            _authorizationService = authorizationService;
            _logger = logger;
            _mapper = mapper;
            _accountManager = accountManager;
        }
        public async Task<bool> Handle(CheckPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _accountManager.CheckPasswordAsync(request.User, request.CurrentPassword);
        }
    }
}
