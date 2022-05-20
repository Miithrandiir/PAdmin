using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAdmin.API.Models;
using PAdmin.Core.Business;
using PAdmin.Entity;

namespace PAdmin.API.Controllers;

[ApiController]
[Authorize]
[Route("api/maiblox")]
public class MailboxController : Controller
{
    private readonly IUserService _userService;
    private readonly IMailboxService _mailboxService;
    
    public MailboxController(IUserService userService, IMailboxService mailboxService)
    {
        _userService = userService;
        _mailboxService = mailboxService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDomain()
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});

        List<MailBox> mailBoxes = await _mailboxService.GetMailboxesOfUser(user);

        return Ok(mailBoxes.ConvertAll(x => new MailBoxModel(x, Url)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecific(int id)
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});

        MailBox? mailBox = await _mailboxService.Get(id);
        if(mailBox == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "Mailbox not found"});
        if (mailBox.Domain.UserId != user.UserId)
            return Unauthorized(new ErrorModel() {ErrorMessage = "You don't have sufficient permissions"});

        return Ok(new MailBoxModel(mailBox, Url));

    }
}