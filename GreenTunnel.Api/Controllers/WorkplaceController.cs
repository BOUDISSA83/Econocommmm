using AutoMapper;
using GreenTunnel.Application.Factory.Commands.CreateWorkplace;
using GreenTunnel.Application.Workplace.Queries;
using GreenTunnel.Application.Workplace.Queries;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GreenTunnel.Application.Workplace.Commands.UpdateWorkplace;
using GreenTunnel.Application.Workplace.Commands.DeleteWorkplace;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreenTunnel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSender;
        private readonly IMediator _mediator;

        public WorkplaceController(IMapper mapper, IUnitOfWork unitOfWork,
            ILogger<WorkplaceController> logger,
            IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mediator = mediator;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkplaceCommand command)
        {
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
            return Ok(await _mediator.Send(new GetWorkplaceByIdQuery { }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateWorkplaceCommand command)
        {
            //command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteWorkplaceByIdCommand { }));
        }
    }
}
