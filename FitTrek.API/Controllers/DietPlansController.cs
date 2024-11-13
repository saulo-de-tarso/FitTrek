using FitTrek.Application.Common.Pagination;
using FitTrek.Application.DietPlans.Commands.CreateDietPlan;
using FitTrek.Application.DietPlans.Commands.DeleteDietPlan;
using FitTrek.Application.DietPlans.Commands.UpdateDietPlan;
using FitTrek.Application.DietPlans.Dtos;
using FitTrek.Application.DietPlans.Queries.GetDietPlanById;
using FitTrek.Application.DietPlans.Queries.GetDietPlans;
using FitTrek.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FitTrek.API.Controllers;

[ApiController]

[Route("api/dietplans")]
[Authorize(Roles = UserRoles.Nutritionist)]
public class DietPlansController(IMediator mediator) : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> Create([Required]int clientId, CreateDietPlanCommand command)
    {
        command.ClientId = clientId;

        int id = await mediator.Send(command);

        
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }


    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById([Required] int clientId, int id)
    {
        await mediator.Send(new DeleteDietPlanCommand(clientId, id));

        return NoContent();
    }

    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DietPlanDto>>> GetAll([Required] int clientId,[FromQuery] PaginationRequest paginationRequest)
    {
        var nutritionists = await mediator.Send(new GetAllDietPlansQuery(clientId, paginationRequest));

        return Ok(nutritionists);
    }


    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<ActionResult<DietPlanDto>> GetById([Required]int clientId, int id)
    {
        var nutritionists = await mediator.Send(new GetDietPlanByIdQuery(clientId, id));

        return Ok(nutritionists);
    }


    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([Required] int clientId, int id, UpdateDietPlanCommand command)
    {
        command.ClientId = clientId;
        
        command.Id = id;

        await mediator.Send((command));

        return NoContent();
    }






}
