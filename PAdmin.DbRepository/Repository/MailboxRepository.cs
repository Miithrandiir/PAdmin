using Microsoft.EntityFrameworkCore;
using PAdmin.Core.DbRepository;
using PAdmin.DbRepository.Context;
using PAdmin.Entity;

namespace PAdmin.DbRepository.Repository;

public class MailboxRepository : IMailboxRepository
{
    private readonly PAdminContext _ctx;

    public MailboxRepository(PAdminContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<MailBox?> Select(int id)
    {
        return await _ctx.MailBoxes.Include(x => x.Domain)
            .FirstOrDefaultAsync(x => x.MailBoxId == id);
    }

    public async Task<List<MailBox>> SelectUserMailboxes(User user)
    {
        return await _ctx.MailBoxes.Include(x => x.Domain)
            .Where(x => x.Domain.UserId == user.UserId)
            .ToListAsync();
    }

    public async Task<MailBox?> Update(MailBox mailBox)
    {
        _ctx.MailBoxes.Update(mailBox);
        await _ctx.SaveChangesAsync();
        return mailBox;
    }

    public async Task Delete(int id)
    {
        MailBox? mailBox = await Select(id);
        if (mailBox == null)
            return;
        _ctx.MailBoxes.Remove(mailBox);
    }
}