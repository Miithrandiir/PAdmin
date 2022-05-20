using Microsoft.AspNetCore.Mvc;

namespace PAdmin.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("test");
    }
}