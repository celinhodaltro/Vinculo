using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vinculo.Application.Commands;
using Vinculo.Application.DTOs;
using Vinculo.Application.Queries;

namespace Vinculo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetPersonByIdQuery(id));
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, $"Pessoa criada com sucesso! Id: {id}");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(RemovePersonCommand command)
    {
        var isDeleted = await _mediator.Send(command);
        if (!isDeleted)
            return NotFound();
        return Ok();
    }


}
