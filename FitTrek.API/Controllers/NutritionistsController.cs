using FitTrek.Application.Nutritionists;
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
}
