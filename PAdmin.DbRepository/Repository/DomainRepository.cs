using Microsoft.EntityFrameworkCore;
using PAdmin.Core.DbRepository;
using PAdmin.DbRepository.Context;
using PAdmin.Entity;

namespace PAdmin.DbRepository.Repository;

public class DomainRepository : IDomainRepository
{
    private readonly PAdminContext _ctx;

    public DomainRepository(PAdminContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Domain>> SelectDomainOfUser(int userId)
    {
        return await _ctx.Domains.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<List<Domain>> SelectDomainOfUser(User user)
    {
        return await SelectDomainOfUser(user.UserId);
    }

    public async Task<Domain> InsertDomain(Domain domain)
    {
        await _ctx.Domains.AddAsync(domain);
        await _ctx.SaveChangesAsync();

        return domain;
    }

    public async Task<Domain?> SelectDomain(int domainId)
    {
        return await _ctx.Domains.Include(x => x.MailBoxes)
            .Include(x => x.Aliases)
            .Include(x => x.DomainAliases)
            .FirstOrDefaultAsync(x => x.DomainId == domainId);
    }

    public async Task DeleteDomain(Domain domain)
    {
        _ctx.Domains.Remove(domain);
        await _ctx.SaveChangesAsync();
    }
}