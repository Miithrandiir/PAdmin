using System.Security.Claims;
using PAdmin.Core.Business;
using PAdmin.Core.DbRepository;
using PAdmin.Entity;

namespace PAdmin.Business;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User?> GetUserAsync(ClaimsPrincipal claim)
    {
        if (claim.Identity == null || claim.Identity.Name == null)
            return null;
        User? user = await _userRepository.Get(claim.Identity.Name);
        if (user == null)
            return null;

        return user;
    }
}