using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAdmin.API.Forms;
using PAdmin.API.Models;
using PAdmin.Core.Business;
using PAdmin.Entity;

namespace PAdmin.API.Controllers;

[ApiController]
[Authorize]
[Route("api/user")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IPasswordHashService _passwordHashService;

    public UserController(IUserService userService, IPasswordHashService passwordHashService)
    {
        _userService = userService;
        _passwordHashService = passwordHashService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});

        return Ok(new UserModel(user, null));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] [Required] UserForm form)
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});

        var retrievedUser = await _userService.GetById(id);
        if (retrievedUser == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User #" + id + " not found"});

        if (retrievedUser.UserId != user.UserId)
            return Unauthorized(new ErrorModel() {ErrorMessage = "You don't have sufficient permissions"});

        retrievedUser.Email = form.Email;
        retrievedUser.Firstname = form.Firstname;
        retrievedUser.Lastname = form.Lastname;
        retrievedUser.Password = await _passwordHashService.HashPassword(form.Password);

        return Ok(new UserModel(await _userService.Update(retrievedUser), null));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});
        
        if(user.Roles != "ROLE_ADMIN")
            return Unauthorized(new ErrorModel() {ErrorMessage = "You don't have sufficient permissions"});

        await _userService.Remove(id);
        return new StatusCodeResult(StatusCodes.Status204NoContent);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] [Required] UserForm form)
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});
        
        if(user.Roles != "ROLE_ADMIN")
            return Unauthorized(new ErrorModel() {ErrorMessage = "You don't have sufficient permissions"});

        User newUser = new User()
        {
             Email = form.Email,
             Firstname = form.Firstname,
             Lastname = form.Lastname,
             Password = await _passwordHashService.HashPassword(form.Password)
        };

        return Ok(new UserModel(await _userService.Create(user), ""));
    }
}