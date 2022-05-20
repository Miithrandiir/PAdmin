using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAdmin.API.Forms;
using PAdmin.API.Models;
using PAdmin.Core.Business;
using PAdmin.Entity;

namespace PAdmin.API.Controllers;

[ApiController, Authorize]
[Route("api/domain")]
public class DomainController : Controller
{
    private readonly IUserService _userService;
    private readonly IDomainService _domainService;

    public DomainController(IUserService userService, IDomainService domainService)
    {
        _userService = userService;
        _domainService = domainService;
    }

    /// <summary>
    /// Get all domains of a user
    /// </summary>
    /// <returns>List of domains</returns>
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});

        List<Domain> domains = await _domainService.GetDomains(user);
        var domainsModel = domains.ConvertAll<DomainModel>(x => new DomainModel(x, Url));
        return Ok(domainsModel);
    }

    /// <summary>
    /// Get one domain with identifier
    /// </summary>
    /// <param name="id">Identifier of the domain</param>
    /// <returns>A Domain</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});

        Domain? domain = await _domainService.GetDomain(id);
        if (domain == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "Domain not found"});

        if (domain.UserId != user.UserId)
            return Unauthorized(new ErrorModel() {ErrorMessage = "You don't have sufficient permissions"});

        return Ok(new DomainModel(domain, Url));
    }

    /// <summary>
    /// Create a domain
    /// </summary>
    /// <param name="form"></param>
    /// <returns>The new domain</returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateDomain([FromBody] [Required] DomainForm form)
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});

        Domain domain = new Domain() {DomainName = form.Name, IsActive = form.IsActive, UserId = user.UserId};
        var newDomain = await _domainService.CreateDomain(domain);


        return Ok(new DomainModel(newDomain, Url));
    }

    /// <summary>
    /// Update the name and if it's activate
    /// </summary>
    /// <param name="id">Identifier of the domain</param>
    /// <param name="form"></param>
    /// <returns>A domain</returns>
    /// <response code="200">Domain updated successfully</response>
    /// <response code="401">User not found or Domain not found</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDomain(int id, [FromBody] [Required] DomainForm form)
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});

        Domain? domain = await _domainService.GetDomain(id);
        if (domain == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "Domain #" + id + " not found"});

        if (domain.UserId != user.UserId)
            return Unauthorized(new ErrorModel() {ErrorMessage = "You don't have sufficient permissions"});

        domain.DomainName = form.Name;
        domain.IsActive = form.IsActive;

        return Ok();
    }

    /// <summary>
    /// Delete a domain
    /// </summary>
    /// <param name="id">Identifier of the domain</param>
    /// <returns>The domain</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDomain(int id)
    {
        User? user = await _userService.GetUserAsync(User);
        if (user == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "User not found"});

        Domain? domain = await _domainService.GetDomain(id);
        if (domain == null)
            return Unauthorized(new ErrorModel() {ErrorMessage = "Domain #" + id + " not found"});

        if (domain.UserId != user.UserId)
            return Unauthorized(new ErrorModel() {ErrorMessage = "You don't have sufficient permissions"});

        return new StatusCodeResult(StatusCodes.Status204NoContent);
    }
}