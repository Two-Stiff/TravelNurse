using Microsoft.AspNetCore.Mvc;
using TravelNurseServer.Dtos.Common.Get;
using TravelNurseServer.Dtos.Jobs.Get;
using TravelNurseServer.Services;

namespace TravelNurseServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProviderController : ControllerBase
{
    private readonly IDisciplineService _disciplineService;
    private readonly IJobService _jobService;

    public ProviderController(
        IDisciplineService  disciplineService,
        IJobService jobService
    )
    {
        _disciplineService  = disciplineService;
        _jobService = jobService;
    }
    
    [HttpGet]
    public IActionResult Get() => Ok("Provider");
    
    [HttpGet("GetDisciplines")]
    public async Task<ActionResult<GetDisciplineDto>> GetDisciplines()
    {
        var result = await _disciplineService.GetDisciplines();
        return Ok(result);
    }
    
    [HttpGet("Jobs")]
    public async Task<ActionResult<GetJobDto>> GetJobs()
    {
        var result = await _jobService.GetJobs();
        return Ok(result);
    }
}