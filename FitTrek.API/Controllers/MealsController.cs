using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Meals.Commands.CreateMeal;
using FitTrek.Application.Meals.Commands.DeleteMeal;
using FitTrek.Application.Meals.Commands.UpdateMeal;
using FitTrek.Application.Meals.Dtos;
using FitTrek.Application.Meals.Queries.GetMeals;
using FitTrek.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FitTrek.API.Controllers;

[ApiController]

[Route("api/dietplans/{dietPlanId}/meals")]
[Authorize(Roles = UserRoles.Nutritionist)]
public class MealsController(IMediator mediator) : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> Create([Required] int dietPlanId, CreateMealCommand command)
    {
        command.DietPlanId = dietPlanId;

        int id = await mediator.Send(command);

        return Created();

        //return CreatedAtAction(nameof(GetById), new { id }, null);
    }


    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById([Required] int dietPlanId, int id)
    {
        await mediator.Send(new DeleteMealCommand(dietPlanId, id));

        return NoContent();
    }



    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MealDto>>> GetAll([Required] int dietPlanId)
    {
        var nutritionists = await mediator.Send(new GetAllMealsQuery(dietPlanId));

        return Ok(nutritionists);
    }


    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([Required] int dietPlanId, int id, UpdateMealCommand command)
    {
        command.DietPlanId = dietPlanId;

        command.Id = id;

        await mediator.Send((command));

        return NoContent();
    }



}

