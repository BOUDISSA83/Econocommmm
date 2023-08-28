

using AutoMapper;
using DAL;
using GreenTunnel.Application.Factory.Commands.CreateFactory;
using GreenTunnel.Application.Factory.Commands.DeleteFactory;
using GreenTunnel.Application.Factory.Commands.UpdateFactory;
using GreenTunnel.Application.Factory.Queries;
using GreenTunnel.Infrastructure;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTunnel.Api.Controllers
{
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

        public FactoryController(IMapper mapper, IUnitOfWork unitOfWork,
            ILogger<FactoryController> logger,
            IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFactoryCommand command)
        {
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
            return Ok(await _mediator.Send(new GetFactoryByIdQuery {}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFactoryCommand command)
        {
            //command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteFactoryByIdCommand {  }));
        }
    }
}
