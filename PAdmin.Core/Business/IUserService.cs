using System.Security.Claims;
using PAdmin.Entity;

namespace PAdmin.Core.Business;

public interface IUserService
{
    public Task<User?> GetUserAsync(ClaimsPrincipal user);
}