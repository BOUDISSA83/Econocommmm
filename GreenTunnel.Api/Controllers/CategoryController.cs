using GreenTunnel.Application.Categories.Commands.CreateCategory;
using GreenTunnel.Application.Categories.Commands.UpdateInputType;
using GreenTunnel.Application.Categories.Queries;
using GreenTunnel.Application.InputType.Commands.CreateInputType;
using GreenTunnel.Application.InputTypes.Commands.DeleteCategory;
using GreenTunnel.Application.InputTypes.Commands.DeleteInputType;
using GreenTunnel.Application.InputTypes.Commands.UpdateInputType;
using GreenTunnel.Application.InputTypes.Queries;
using GreenTunnel.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenTunnel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(IMediator mediator,
            UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var user = await GetCurrentUserAsync();
            //command.Model.UserId = user.Id;
            //command.Model.CreatedBy = user.FullName;
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCatgoriesListQuery()));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCategoryCommand { CategoryId = id }));
        }
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}
