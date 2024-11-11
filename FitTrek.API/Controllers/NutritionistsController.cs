using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Nutritionists.Commands.CreateNutritionist;
using FitTrek.Application.Nutritionists.Commands.DeleteNutritionist;
using FitTrek.Application.Nutritionists.Commands.UpdateNutritionist;
using FitTrek.Application.Nutritionists.Dtos;
using FitTrek.Application.Nutritionists.Queries.GetNutritionistById;
using FitTrek.Application.Nutritionists.Queries.GetNutritionists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitTrek.API.Controllers;

[ApiController]
[Route("api/nutritionists")]
public class NutritionistsController(IMediator mediator) : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateNutritionistCommand command)
    {
        int id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteNutritionistCommand(id));

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NutritionistDto>>> GetAll(string? name, [FromQuery]PaginationRequest paginationRequest)
    {
        var nutritionists = await mediator.Send(new GetAllNutritionistsQuery(name, paginationRequest));

        return Ok(nutritionists);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<ActionResult<NutritionistDto?>> GetById(int id)
    {
        var nutritionist = await mediator.Send(new GetNutritionistByIdQuery(id));
             
          
        return Ok(nutritionist);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, UpdateNutritionistCommand command)
    {
        command.Id = id;

        await mediator.Send((command));
        
        return NoContent();
    }




}
