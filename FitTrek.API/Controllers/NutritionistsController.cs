using FitTrek.Application.Nutritionists;
using FitTrek.Application.Nutritionists.Commands.CreateNutritionist;
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
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var nutritionists = await mediator.Send(new GetAllNutritionistsQuery());

        return Ok(nutritionists);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var nutritionist = await mediator.Send(new GetNutritionistByIdQuery(id));

        if(nutritionist is null)
            return NotFound();
          
        return Ok(nutritionist);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNutritionistCommand command)
    {
        int id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }


}
