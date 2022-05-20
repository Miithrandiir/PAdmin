using PAdmin.Entity;

namespace PAdmin.Core.DbRepository;

public interface IMailboxRepository
{
    public Task<MailBox?> Select(int id);
    public Task<List<MailBox>> SelectUserMailboxes(User user);
    public Task<MailBox?> Update(MailBox mailBox);
    public Task Delete(int id);
}