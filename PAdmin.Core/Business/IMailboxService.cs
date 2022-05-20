using PAdmin.Entity;

namespace PAdmin.Core.Business;

public interface IMailboxService
{
    public Task<MailBox?> Get(int id);
    public Task<List<MailBox>> GetMailboxesOfUser(User user);
    public Task<bool> IsTheMailboxAlreadyExists(string mailbox, int domainId);
    public Task<MailBox?> Update(MailBox mailBox);
    public Task<MailBox> Create(MailBox mailbox); 
    public Task Remove(int id);
}