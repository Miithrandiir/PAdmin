using PAdmin.Entity;

namespace PAdmin.Core.DbRepository;

public interface IUserRepository
{
    public Task<User?> Get(int id);
    public Task<User?> Get(string username);

    public Task<User?> HasLoggedIn(User user, DateTime date);
    public Task<User> Insert(User user);
    public Task<User> Update(User user);

    public Task Delete(int id);
}