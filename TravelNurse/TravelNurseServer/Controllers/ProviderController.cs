using Microsoft.AspNetCore.Mvc;

namespace TravelNurseServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProviderController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Provider");
}