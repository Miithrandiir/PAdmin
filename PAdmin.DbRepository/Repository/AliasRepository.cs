using Microsoft.EntityFrameworkCore;
using PAdmin.Core.DbRepository;
using PAdmin.DbRepository.Context;
using PAdmin.Entity;

namespace PAdmin.DbRepository.Repository;

public class AliasRepository : IAliasRepository
{
    private readonly PAdminContext _ctx;

    public AliasRepository(PAdminContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Alias?> Select(int id)
    {
        return await _ctx.Aliases.FirstOrDefaultAsync(x => x.AliasId == id);
    }

    public async Task<List<Alias>> SelectUserAliases(User user)
    {
        return await _ctx.Aliases.Include(x => x.Domain).Where(x => x.Domain.UserId == user.UserId).ToListAsync();
    }

    public async Task<Alias?> GetAliasByNameAndDomain(string alias, int domainId)
    {
        return await _ctx.Aliases.FirstOrDefaultAsync(x => x.From == alias && x.DomainId == domainId);
    }

    public async Task<Alias> Update(Alias alias)
    {
        _ctx.Aliases.Update(alias);
        await _ctx.SaveChangesAsync();
        return alias;
    }

    public async Task<Alias> Insert(Alias alias)
    {
        await _ctx.Aliases.AddAsync(alias);
        await _ctx.SaveChangesAsync();
        return alias;
    }

    public async Task Delete(int id)
    {
        var alias = await Select(id);
        if (alias == null)
            return;

        _ctx.Aliases.Remove(alias);
        await _ctx.SaveChangesAsync();
    }
}