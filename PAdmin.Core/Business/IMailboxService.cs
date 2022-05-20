using PAdmin.Entity;

namespace PAdmin.Core.Business;

public interface IMailboxService
{
    public Task<MailBox?> Get(int id);
    public Task<List<MailBox>> GetMailboxesOfUser(User user);
    public Task<MailBox?> Update(MailBox mailBox);
    public Task Remove(int id);
}