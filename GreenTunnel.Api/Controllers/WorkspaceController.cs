using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using GreenTunnel.Application.Workspace.Commands.CreateWorkspace;
using GreenTunnel.Application.Workspace.Queries;
using GreenTunnel.Application.Workspace.Commands.UpdateWorkspace;
using GreenTunnel.Application.Workspace.Commands.DeleteWorkspace;
using Microsoft.AspNetCore.Authorization;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkSpace;
using GreenTunnel.Application.Workspaces.Queries;

namespace GreenTunnel.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class WorkSpaceController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;
    private readonly UserManager<ApplicationUser> _userManager;

    public WorkSpaceController(
        ILogger<WorkSpaceController> logger,
        IMediator mediator,
        UserManager<ApplicationUser> userManager)
    {
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
    private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
}
