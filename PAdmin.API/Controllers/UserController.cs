using Microsoft.AspNetCore.Mvc;

namespace PAdmin.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("test");
    }
}