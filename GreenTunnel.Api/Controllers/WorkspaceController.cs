using AutoMapper;
using GreenTunnel.Application.Workspaces.Commands.CreateWorkspace;
using GreenTunnel.Application.Workspaces.Commands.DeleteWorkspace;
using GreenTunnel.Application.Workspaces.Commands.UpdateWorkspace;
using GreenTunnel.Application.Workspaces.Queries;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces.Uow;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkSpaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenTunnel.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class WorkSpaceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;
    private readonly IEmailSender _emailSender;
    private readonly IMediator _mediator;
    private readonly UserManager<ApplicationUser> _userManager;

    public WorkSpaceController(IMapper mapper, IUnitOfWork unitOfWork,
        ILogger<WorkSpaceController> logger,
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
    public async Task<IActionResult> Create(CreateWorkspaceCommand command)
    {
        var user = await GetCurrentUserAsync();
        command.Model.UserId = user.Id;
        command.Model.CreatedBy = user.FullName;
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllWorkspaceQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetWorkSpaceQuery { WorkSpaceId = id }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateWorkspaceCommand command)
    {
        var user = await GetCurrentUserAsync();
        command.Model.UserId = user.Id;
        command.Model.UpdatedBy = user.FullName;
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _mediator.Send(new DeleteWorkSpaceCommand { WorkspaceId = id }));
    }
    [HttpGet("workspaces")]
    //[Authorize(Policies.ViewAllUsersPolicy)]
    [ProducesResponseType(200, Type = typeof(List<GetWorkspacesListResponseModel>))]
    public async Task<IActionResult> GetWorkspacesList()
    {
        var result = await _mediator.Send(new GetWorkspacesListQuery());
        return Ok(result);
    }
    [HttpGet("Allworkspaces")]
    //[Authorize(Policies.ViewAllUsersPolicy)]
    [ProducesResponseType(200, Type = typeof(List<WorkSpaceViewModel>))]
    public async Task<IActionResult> GetWorkSpaces(int pageNumber, int pageSize, [FromQuery] int? workplaceId = null, [FromQuery] string? searchTerm = null, [FromQuery] string? sortColumn = null, [FromQuery] string? sortOrder = null)
    {
        var result = await _mediator.Send(new GetAllWorkspaceQuery { SortColumn = sortColumn, SortOrder = sortOrder, SearchTerm = searchTerm, PageNumber = pageNumber, PageSize = pageSize, WorkplaceId = workplaceId });
        return Ok(result);
    }
    [HttpGet("validateDuplicateName/{name}/workspaceId/{workspaceId}")]
    public async Task<IActionResult> GetValidatedDuplicate(string name,int workspaceId)
    {
        return Ok(await _mediator.Send(new GetDuplicateWorkspaceQuery { Name = name, WorkspaceId = workspaceId }));
    }
    private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

}