using PAdmin.Entity;

namespace PAdmin.Core.Business;

public interface IAliasService
{
    public Task<Alias?> Get(int id);
    public Task<List<Alias>> GetAliasesOfUser(User user);
    public Task<bool> IsTheAliasAlreadyExists(string alias, int domainId);
    public Task<Alias> Update(Alias alias);
    public Task<Alias> Create(Alias alias); 
    public Task Remove(int id);
}