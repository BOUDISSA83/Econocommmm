﻿using AutoMapper;
using GreenTunnel.Application.Factory.Commands.CreateWorkplace;
using GreenTunnel.Application.Workplace.Queries;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GreenTunnel.Application.Workplace.Commands.UpdateWorkplace;
using GreenTunnel.Application.Workplace.Commands.DeleteWorkplace;
using Microsoft.AspNetCore.Identity;
using GreenTunnel.Core.Entities;
using GreenTunnel.Application.Factory.Queries;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using Microsoft.AspNetCore.Authorization;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlace;
using GreenTunnel.Application.Workplaces.Queries;

namespace GreenTunnel.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSender;
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public WorkplaceController(IMapper mapper, IUnitOfWork unitOfWork,
            ILogger<WorkplaceController> logger,
            IMediator mediator,
            UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mediator = mediator;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkplaceCommand command)
        {
            var user = await GetCurrentUserAsync();
            command.Model.UserId = user.Id;
            command.Model.CreatedBy = user.FullName;
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllWorkplaceQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetWorkplaceQuery { WorkplaceId = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateWorkplaceCommand command)
        {
            var user = await GetCurrentUserAsync();
            command.Model.UserId = user.Id;
            command.Model.UpdatedBy = user.FullName;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteWorkplaceCommand { WorkplaceId = id }));
        }
        [HttpGet("Allworkplaces")]
        //[Authorize(Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(List<WorkplaceViewModel>))]
        public async Task<IActionResult> GetWorkPlaces(int pageNumber, int pageSize, [FromQuery] string? searchTerm = null, [FromQuery] string? sortColumn = null, [FromQuery] string? sortOrder = null, [FromQuery] int? factoryId = null)
        {
            var result = await _mediator.Send(new GetAllWorkplaceQuery { SortColumn = sortColumn, SortOrder = sortOrder, SearchTerm = searchTerm, PageNumber = pageNumber, PageSize = pageSize, FactoryId = factoryId });
            return Ok(result);
        }
        [HttpGet("workplaces")]
        //[Authorize(Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(List<GetWorkplacesListResponseModel>))]
        public async Task<IActionResult> GetWorkPlacesList()
        {
            var result = await _mediator.Send(new GetWorkplacesListQuery());
            return Ok(result);
        }
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

    }
}
