using FitTrek.Application.Clients.Commands.CreateClient;
using FitTrek.Application.Clients.Commands.DeleteClientByIdForNutritionist;
using FitTrek.Application.Clients.Commands.DeleteClientsForNutritionist;
using FitTrek.Application.Clients.Commands.UpdateClient;
using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Clients.Queries.GetClientByIdForNutritionist;
using FitTrek.Application.Clients.Queries.GetClientsForNutritionist;
using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Nutritionists.Dtos;
using FitTrek.Application.Nutritionists.Queries.GetNutritionists;
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

    
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{clientId}")]
    public async Task<IActionResult> DeleteByIdForNutritionist(int nutritionistId, int clientId)
    {
        await mediator.Send(new DeleteClientByIdForNutritionistCommand(nutritionistId, clientId));

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllForNutritionist(int nutritionistId, string? name, [FromQuery] PaginationRequest paginationRequest)
    {
        var nutritionists = await mediator.Send(new GetClientsForNutritionistQuery(nutritionistId, name, paginationRequest));

        return Ok(nutritionists);
    }


    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{clientId}")]
    public async Task<ActionResult<ClientDto>> GetByIdForNutritionist(int nutritionistId, int clientId)
    {
        var nutritionists = await mediator.Send(new GetClientByIdForNutritionistQuery(nutritionistId, clientId));

        return Ok(nutritionists);
    }

    
    [HttpPatch("{clientId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateForNutritionist(int nutritionistId, int clientId, UpdateClientCommand command)
    {
        command.NutritionistId = nutritionistId;
        command.Id = clientId;

        await mediator.Send((command));

        return NoContent();
    }

    




}
