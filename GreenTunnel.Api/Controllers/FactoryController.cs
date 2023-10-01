

using AutoMapper;
using GreenTunnel.Application.Factories.Commands.CreateFactory;
using GreenTunnel.Application.Factories.Commands.DeleteFactory;
using GreenTunnel.Application.Factories.Commands.UpdateFactory;
using GreenTunnel.Application.Factories.Queries;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces.Uow;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenTunnel.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class FactoryController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;
    private readonly IEmailSender _emailSender;
    private readonly IMediator _mediator;
    private readonly UserManager<ApplicationUser> _userManager;

    public FactoryController(IMapper mapper, IUnitOfWork unitOfWork,
        ILogger<FactoryController> logger,
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
    public async Task<IActionResult> Create([FromBody] CreateFactoryCommand command)
    {
        var user = await GetCurrentUserAsync();
        command.Model.UserId = user.Id;
        command.Model.CreatedBy = user.FullName;
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllFactoryQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetFactoryQuery { FactoryId = id }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateFactoryCommand command)
    {
        //command.Id = id;
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _mediator.Send(new DeleteFactoryCommand { FactoryId = id }));
    }
    [HttpGet("Allfactories")]
    //[Authorize(Policies.ViewAllUsersPolicy)]
    [ProducesResponseType(200, Type = typeof(List<FactoryViewModel>))]
    public async Task<IActionResult> GetFactories(int pageNumber, int pageSize, [FromQuery] string? searchTerm = null, [FromQuery] string? sortColumn = null, [FromQuery] string? sortOrder = null)
    {
        var result = await _mediator.Send(new GetAllFactoryQuery { SortColumn = sortColumn, SortOrder = sortOrder, SearchTerm = searchTerm, PageNumber = pageNumber, PageSize = pageSize });
        return Ok(result);
    }

    [HttpGet("factories")]
    //[Authorize(Policies.ViewAllUsersPolicy)]
    [ProducesResponseType(200, Type = typeof(List<GetFacoriesListResponseModel>))]
    public async Task<IActionResult> GetFactoriesList()
    {
        var result = await _mediator.Send(new GetFactoriesListQuery());
        return Ok(result);
    }

    [HttpGet("validateDuplicateName/{name}/factoryId/{factoryId}")]
    public async Task<IActionResult> GetValidatedDuplicate(string name,int factoryId)
    {
        return Ok(await _mediator.Send(new GetDuplicateFactoryQuery { Name = name, FactoryId = factoryId }));
    }
    private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

}