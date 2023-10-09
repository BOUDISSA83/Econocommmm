using GreenTunnel.Application.Test.Commands.CreateTest;
using GreenTunnel.Application.Test.Commands.DeleteTest;
using GreenTunnel.Application.Test.Commands.UpdateTest;
using GreenTunnel.Application.Test.Queries;
using GreenTunnel.Application.TestType.Queries;
using GreenTunnel.Core.Interfaces.Uow;
using GreenTunnel.Infrastructure;
using GreenTunnel.Infrastructure.ViewModels.Response.Test;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GreenTunnel.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public TestController(IUnitOfWork unitOfWork,
    ILogger<WorkplaceController> logger,
    IMediator mediator)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _mediator = mediator;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllTestQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetTestQuery { TestId = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]  UpdateTestCommand command)
        {
            
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            return Ok(await _mediator.Send(new DeleteTestCommand { TestId = id }));
        }

        [HttpGet("Alltests")]
        public async Task<IActionResult> GetTests(int pageNumber, int pageSize, [FromQuery] string? searchTerm = null, [FromQuery] string? sortColumn = null, [FromQuery] string? sortOrder = null)
        {
            var result = await _mediator.Send(new GetAllTestQuery { SortColumn = sortColumn, SortOrder = sortOrder, SearchTerm = searchTerm, PageNumber = pageNumber, PageSize = pageSize });
            return Ok(result);
        }

        [HttpGet("tests")]
        //[Authorize(Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(List<GetTestsListResponseModel>))]
        public async Task<IActionResult> GetTestsList()
        {
            var result = await _mediator.Send(new GetTestsListQuery());
            return Ok(result);
        }
    }
}

