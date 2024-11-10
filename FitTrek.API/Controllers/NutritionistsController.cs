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
}
