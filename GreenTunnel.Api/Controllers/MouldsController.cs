﻿using GreenTunnel.Application.Moulds.Commands.CreateMoulds;
using GreenTunnel.Application.Moulds.Commands.DeleteMoulds;
using GreenTunnel.Application.Moulds.Commands.UpdateMoulds;
using GreenTunnel.Application.Moulds.Queries;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreenTunnel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MouldsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MouldsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/<MouldController>
    [HttpGet]
    public async Task<IActionResult> Get(int id, int page, int pageSize, string searchValue)
    {
        if (id == 0)
        {
            return Ok(await _mediator.Send(new GetAllMouldsQuery() { PageNumber = page, PageSize = pageSize, SearchValue = searchValue }));
        }
        else
        {
            return Ok(await _mediator.Send(new GetMouldsByWorkspaceIdQuery() { Id = id, PageNumber = page, PageSize = pageSize }));
        }
    }

    // GET api/<MouldController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _mediator.Send(new GetMouldsByIdQuery() { Id = id }));
    }
    [HttpGet("validateDuplicateName/{name}")]
    public async Task<IActionResult> GetValidatedDuplicate(string name)
    {
        return Ok(await _mediator.Send(new GetDuplicateMouldQuery { Name = name }));
    }
    // POST api/<MouldController>
    [HttpPost]
    public async Task<IActionResult> Post(CreateMouldsCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    // PUT api/<MouldController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, MouldsViewModel mouldsViewModel)
    {
        if (id != mouldsViewModel.Id)
        {
            return BadRequest();
        }
        UpdateMouldsCommand command = new UpdateMouldsCommand(mouldsViewModel);
        return Ok(await _mediator.Send(command));
    }

    // DELETE api/<MouldController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _mediator.Send(new DeleteMouldsByIdCommand(id) { id = id }));
    }
}