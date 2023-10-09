
using GreenTunnel.Application.Test.Queries;
using GreenTunnel.Application.TestType.Commands.CreateTestType;
using GreenTunnel.Application.TestType.Commands.DeleteTestType;
using GreenTunnel.Application.TestType.Commands.UpdateTestType;
using GreenTunnel.Application.TestType.Queries;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces.Uow;
using GreenTunnel.Infrastructure;
using GreenTunnel.Infrastructure.ViewModels.Response.Test;
using GreenTunnel.Infrastructure.ViewModels.Response.TestType;
using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenTunnel.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager; 

        public TestTypeController(IUnitOfWork unitOfWork,
    ILogger<WorkplaceController> logger,
    IMediator mediator,
    UserManager<ApplicationUser> userManager)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _mediator = mediator;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestTypeCommand command)
        {
            var user = await GetCurrentUserAsync();
            command.Model.UserId = user.Id;
            command.Model.CreatedBy = user.FullName;
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllTestTypeQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetTestTypeQuery { TestTypeId = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update( [FromBody] UpdateTestTypeCommand command)
        {
            
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _mediator.Send(new DeleteTestTypeCommand { TestTypeId = id }));
        }



        [HttpGet("AlltestTypes")]
        public async Task<IActionResult> GetTestTypes(int pageNumber, int pageSize, [FromQuery] string? searchTerm = null, [FromQuery] string? sortColumn = null, [FromQuery] string? sortOrder = null)
        {
            var result = await _mediator.Send(new GetAllTestTypeQuery { SortColumn = sortColumn, SortOrder = sortOrder, SearchTerm = searchTerm, PageNumber = pageNumber, PageSize = pageSize });
            return Ok(result);
        }

        [HttpGet("testtypes")]
        //[Authorize(Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(List<GetTestTypesListResponseModel>))]
        public async Task<IActionResult> GetTestTypesList()
        {
            var result = await _mediator.Send(new GetTestTypesListQuery());
            return Ok(result);
        }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}

