using PAdmin.Entity;

namespace PAdmin.Core.Business;

public interface IDomainService
{
    public Task<List<Domain>> GetDomains(int userId);
    public Task<List<Domain>> GetDomains(User user);
    public Task<Domain> CreateDomain(Domain domain);

    public Task<Domain?> GetDomain(int domainId);

    public Task RemoveDomain(Domain domain);
}