using GreenTunnel.Application.InputType.Commands.CreateInputType;
using GreenTunnel.Application.InputTypes.Commands.DeleteInputType;
using GreenTunnel.Application.InputTypes.Commands.UpdateInputType;
using GreenTunnel.Application.InputTypes.Queries;
using GreenTunnel.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenTunnel.Api.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InputTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public InputTypeController(IMediator mediator,
            UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInputTypeCommand command)
        {
            var user = await GetCurrentUserAsync();
            //command.Model.UserId = user.Id;
            //command.Model.CreatedBy = user.FullName;
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllInputTypesListQuery()));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInputTypeCommand command)
        {
            //command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteInputTypeCommand { InputTypeId = id }));
        }
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);


    }
}
