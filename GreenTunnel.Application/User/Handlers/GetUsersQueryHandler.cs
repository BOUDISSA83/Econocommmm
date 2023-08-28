using AutoMapper;
using GreenTunnel.Application.CQRS.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels;
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
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserViewModel>>
    {

        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<GetUsersQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;

        public GetUsersQueryHandler(IAuthorizationService authorizationService,
            IMapper mapper,
            ILogger<GetUsersQueryHandler> logger,
            IAccountManager accountManager)
        {
            _authorizationService = authorizationService;
            _logger = logger;
            _mapper = mapper;
            _accountManager = accountManager;
        }
        public async Task<List<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var usersAndRoles = await _accountManager.GetUsersAndRolesAsync(request.PageNumber, request.PageSize);

            var usersVM = new List<UserViewModel>();

            foreach (var item in usersAndRoles)
            {
                var userVM = _mapper.Map<UserViewModel>(item.User);
                userVM.Roles = item.Roles;

                usersVM.Add(userVM);
            }

            return usersVM;
        }
    }
}
