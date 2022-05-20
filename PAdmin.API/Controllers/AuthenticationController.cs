using Microsoft.AspNetCore.Mvc;
using PAdmin.API.Forms;
using PAdmin.API.Models;
using PAdmin.Core.Business;
using PAdmin.Core.DbRepository;
using PAdmin.Entity;

namespace PAdmin.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : Controller
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashService;

    public AuthenticationController(IAuthService authService, IUserRepository userRepository,
        IPasswordHashService passwordHashService)
    {
        _authService = authService;
        _userRepository = userRepository;
        _passwordHashService = passwordHashService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> login([FromBody] LoginForm form)
    {
        User? user = await _userRepository.Get(form.email);
        if (user == null)
            return Unauthorized(new ErrorModel()
                {ErrorMessage = "User not found OR Password not found", ErrorCode = null});

        bool compareHash = await _passwordHashService.ComparePassword(form.password, user.Password);
        if (!compareHash)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found OR Password not found"});

        string key = await _authService.Login(user);
        await _userRepository.HasLoggedIn(user, DateTime.Now);

        return Ok(new UserModel(user, key));
    }
}