using FitTrek.Application.Nutritionists;
using FitTrek.Application.Nutritionists.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FitTrek.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NutritionistsController(INutritionistsService nutritionistsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var nutritionists = await nutritionistsService.Get();

        return Ok(nutritionists);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var nutritionist = await nutritionistsService.GetById(id);
        if(nutritionist is null)
            return NotFound();
          
        return Ok(nutritionist);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNutritionistDto createNutritionistDto)
    {
        int id = await nutritionistsService.Create(createNutritionistDto);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }


}
