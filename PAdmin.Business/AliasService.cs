using PAdmin.Core.Business;
using PAdmin.Core.DbRepository;
using PAdmin.Entity;

namespace PAdmin.Business;

public class AliasService : IAliasService
{
    private readonly IAliasRepository _aliasRepository;

    public AliasService(IAliasRepository aliasRepository)
    {
        _aliasRepository = aliasRepository;
    }

    public async Task<Alias?> Get(int id)
    {
        return await _aliasRepository.Select(id);
    }

    public async Task<List<Alias>> GetAliasesOfUser(User user)
    {
        return await _aliasRepository.SelectUserAliases(user);
    }

    public async Task<bool> IsTheAliasAlreadyExists(string alias, int domainId)
    {
        return (await _aliasRepository.GetAliasByNameAndDomain(alias, domainId)) != null;
    }

    public async Task<Alias> Update(Alias alias)
    {
        return await _aliasRepository.Update(alias);
    }

    public async Task<Alias> Create(Alias alias)
    {
        return await _aliasRepository.Insert(alias);
    }

    public async Task Remove(int id)
    {
        await _aliasRepository.Delete(id);
    }
}