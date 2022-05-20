using Microsoft.EntityFrameworkCore;
using PAdmin.Core.DbRepository;
using PAdmin.DbRepository.Context;
using PAdmin.Entity;

namespace PAdmin.DbRepository.Repository;

public class UserRepository : IUserRepository
{

    private readonly PAdminContext _ctx;
    
    public UserRepository(PAdminContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<User?> Get(int id)
    {
        return await _ctx.Users.FirstOrDefaultAsync(x => x.UserId == id);
    }

    public async Task<User?> Get(string email)
    {
        return await _ctx.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> HasLoggedIn(User user, DateTime date)
    {
        user.LastConnection = date;
        await Update(user);
        return user;
    }

    public async Task<User> Insert(User user)
    {
        await _ctx.Users.AddAsync(user);
        await _ctx.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(User user)
    {
        _ctx.Users.Update(user);
        await _ctx.SaveChangesAsync();
        return user;
    }

    public async Task Delete(int id)
    {
        var user = await Get(id);
        if (user == null)
            return;

        _ctx.Users.Remove(user);
        await _ctx.SaveChangesAsync();
    }
}