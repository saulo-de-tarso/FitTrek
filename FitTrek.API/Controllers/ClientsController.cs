using FitTrek.Application.Clients.Commands.CreateClient;
using FitTrek.Application.Clients.Commands.DeleteClientsForNutritionist;
using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Clients.Queries.GetClientByIdForNutritionist;
using FitTrek.Application.Clients.Queries.GetClientsForNutritionist;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitTrek.API.Controllers;

[ApiController]
[Route("api/nutritionists/{nutritionistId}/clients")]
public class ClientsController(IMediator mediator) : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> Create(int nutritionistId, CreateClientCommand command)
    {
        command.NutritionistId = nutritionistId;

        int clientId = await mediator.Send(command);

        return CreatedAtAction(nameof(GetByIdForNutritionist), new { nutritionistId, clientId }, null);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete]
    public async Task<IActionResult> DeleteAllForNutritionist(int nutritionistId)
    {
        await mediator.Send(new DeleteClientsForNutritionistCommand(nutritionistId));

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllForNutritionist(int nutritionistId)
    {
        var nutritionists = await mediator.Send(new GetClientsForNutritionistQuery(nutritionistId));

        return Ok(nutritionists);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{clientId}")]
    public async Task<ActionResult<ClientDto>> GetByIdForNutritionist(int nutritionistId, int clientId)
    {
        var nutritionists = await mediator.Send(new GetClientByIdForNutritionistQuery(nutritionistId, clientId));

        return Ok(nutritionists);
    }

    /*
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDto?>> GetById(int id)
    {
        var nutritionist = await mediator.Send(new GetClientByIdQuery(id));


        return Ok(nutritionist);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, UpdateClientCommand command)
    {
        command.Id = id;


        return NotFound();
    }

    */


}
