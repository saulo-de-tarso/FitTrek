using FitTrek.Application.Clients.Commands.CreateClient;
using FitTrek.Application.Clients.Commands.DeleteClient;
using FitTrek.Application.Clients.Commands.UpdateClient;
using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Clients.Queries.GetClientById;
using FitTrek.Application.Clients.Queries.GetClients;
using FitTrek.Application.Common.Pagination;
using FitTrek.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitTrek.API.Controllers;

[ApiController]

[Route("api/clients")]
[Authorize(Roles = UserRoles.Nutritionist)]
public class ClientsController(IMediator mediator) : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateClientCommand command)
    {
       
        int id = await mediator.Send(command);

        //return Created();
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        await mediator.Send(new DeleteClientCommand(id));

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll(string? name, [FromQuery] PaginationRequest paginationRequest)
    {
        var nutritionists = await mediator.Send(new GetAllClientsQuery(name, paginationRequest));

        return Ok(nutritionists);
    }


    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDto>> GetById(int id)
    {
        var nutritionists = await mediator.Send(new GetClientByIdQuery(id));

        return Ok(nutritionists);
    }

    
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateForNutritionist(int id, UpdateClientCommand command)
    {
        command.Id = id;

        await mediator.Send((command));

        return NoContent();
    }

    




}
