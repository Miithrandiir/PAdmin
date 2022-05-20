using PAdmin.Core.Business;
using PAdmin.Core.DbRepository;
using PAdmin.Entity;

namespace PAdmin.Business;

public class MailboxService : IMailboxService
{
    private readonly IMailboxRepository _mailboxRepository;
    
    public MailboxService(IMailboxRepository mailboxRepository)
    {
        _mailboxRepository = mailboxRepository;
    }
    
    public async Task<MailBox?> Get(int id)
    {
        return await _mailboxRepository.Select(id);
    }

    public async Task<List<MailBox>> GetMailboxesOfUser(User user)
    {
        return await _mailboxRepository.SelectUserMailboxes(user);
    }

    public async Task<MailBox?> Update(MailBox mailBox)
    {
        return await _mailboxRepository.Update(mailBox);
    }

    public async Task Remove(int id)
    {
        await _mailboxRepository.Delete(id);
    }
}