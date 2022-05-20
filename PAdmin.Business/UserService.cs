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

    public async Task<User?> GetById(int id)
    {
        return await _userRepository.Get(id);
    }

    public async Task<User?> Update(User user)
    {
        return await _userRepository.Update(user);
    }

    public async Task Remove(int id)
    {
        await _userRepository.Delete(id);
    }

    public async Task<User> Create(User user)
    {
        return await _userRepository.Insert(user);
    }
}