using PAdmin.Entity;

namespace PAdmin.Core.DbRepository;

public interface IAliasRepository
{
    public Task<Alias?> Select(int id);
    public Task<List<Alias>> SelectUserAliases(User user);

    public Task<Alias?> GetAliasByNameAndDomain(string alias, int domainId); 
    public Task<Alias> Update(Alias alias);
    public Task<Alias> Insert(Alias alias); 
    public Task Delete(int id);
}