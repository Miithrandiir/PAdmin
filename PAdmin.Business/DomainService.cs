using PAdmin.Core.Business;
using PAdmin.Core.DbRepository;
using PAdmin.Entity;

namespace PAdmin.Business;

public class DomainService : IDomainService
{

    private readonly IDomainRepository _domainRepository;

    public DomainService(IDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }
    
    public async Task<List<Domain>> GetDomains(int userId)
    {
        return await _domainRepository.SelectDomainOfUser(userId);
    }

    public async Task<List<Domain>> GetDomains(User user)
    {
        return await GetDomains(user.UserId);
    }

    public async Task<Domain> CreateDomain(Domain domain)
    {
        return await _domainRepository.InsertDomain(domain);
    }

    public async Task<Domain?> GetDomain(int domainId)
    {
        return await _domainRepository.SelectDomain(domainId);
    }

    public async Task RemoveDomain(Domain domain)
    {
        await _domainRepository.DeleteDomain(domain);
    }
}