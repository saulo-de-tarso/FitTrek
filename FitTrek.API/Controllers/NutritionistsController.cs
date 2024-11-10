using FitTrek.Application.Nutritionists;
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
[Route("api/[controller]")]
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

        return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NutritionistDto>>> GetAll()
    {
        var nutritionists = await mediator.Send(new GetAllNutritionistsQuery());

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
        

        return NotFound();
    }




}
