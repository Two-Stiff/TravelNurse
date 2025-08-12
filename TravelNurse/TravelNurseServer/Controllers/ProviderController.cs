using Microsoft.AspNetCore.Mvc;
using TravelNurseServer.Dtos.Common.Get;
using TravelNurseServer.Services;

namespace TravelNurseServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProviderController : ControllerBase
{
    private readonly IDisciplineService _disciplineService;

    public ProviderController(
        IDisciplineService  disciplineService
    )
    {
        _disciplineService  = disciplineService;
    }
    
    [HttpGet]
    public IActionResult Get() => Ok("Provider");
    
    [HttpGet("GetDisciplines")]
    public async Task<ActionResult<GetDisciplineDto>> GetDisciplines()
    {
        var result = await _disciplineService.GetDisciplines();
        return Ok(result);
    }
}