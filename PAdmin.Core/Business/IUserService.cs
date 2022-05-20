using System.Security.Claims;
using PAdmin.Entity;

namespace PAdmin.Core.Business;

public interface IUserService
{
    public Task<User?> GetUserAsync(ClaimsPrincipal user);
    public Task<User?> GetById(int id);

    public Task<User?> Update(User user);

    public Task Remove(int id);

    public Task<User> Create(User user);
}