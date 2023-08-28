﻿using AutoMapper;
using GreenTunnel.Application.User.Commands.UpdateUser;
using GreenTunnel.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.User.Handlers.Commands
{
    public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand, (bool Succeeded, string[] Errors)>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<UpdateUserPasswordCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;

        public UpdateUserPasswordCommandHandler(IAuthorizationService authorizationService,
            IMapper mapper,
            ILogger<UpdateUserPasswordCommandHandler> logger,
            IAccountManager accountManager)
        {
            _authorizationService = authorizationService;
            _logger = logger;
            _mapper = mapper;
            _accountManager = accountManager;
        }

        public async Task<(bool Succeeded, string[] Errors)> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _accountManager.UpdatePasswordAsync(request.ApplicationUser, request.CurrentPassword, request.NewPassword);
        }
    }
}
