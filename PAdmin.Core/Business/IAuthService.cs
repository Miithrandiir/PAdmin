using PAdmin.Entity;

namespace PAdmin.Core.Business;

public interface IAuthService
{
    public Task<string> Login(User user);
    public Task<bool> Refresh(string email);
}