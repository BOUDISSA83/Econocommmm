using AutoMapper;
using GreenTunnel.Application.Role.Queries;
using GreenTunnel.Application.User.Queries;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
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

    public class GetRolesLoadRelatedQueryHandler : IRequestHandler<GetRolesLoadRelatedQuery, PagedList<ApplicationRole>>
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
        public async Task<PagedList<ApplicationRole>> Handle(GetRolesLoadRelatedQuery request, CancellationToken cancellationToken)
        {
          var rolesList =  await _accountManager.GetRolesLoadRelatedAsync(request.SortColumn, request.SortOrder, request.SearchTerm, request.Page, request.PageSize);
            var factoryViewModels = _mapper.Map<List<ApplicationRole>>(rolesList.Items);

            var pagedList = new PagedList<ApplicationRole>(
                factoryViewModels,
                request.Page,
                request.PageSize,
                rolesList.TotalCount);

            return pagedList;
        }
    }
}
