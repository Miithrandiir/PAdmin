namespace PAdmin.Core.Business;

public interface IPasswordHashService
{
    public Task<string> HashPassword(string password);
    public Task<bool> ComparePassword(string password, string hash);
}