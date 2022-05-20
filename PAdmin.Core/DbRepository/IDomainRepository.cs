using PAdmin.Entity;

namespace PAdmin.Core.DbRepository;

public interface IDomainRepository
{
    public Task<List<Domain>> SelectDomainOfUser(int userId);
    public Task<List<Domain>> SelectDomainOfUser(User user);

    public Task<Domain> InsertDomain(Domain domain);

    public Task<Domain?> SelectDomain(int domainId);

    public Task DeleteDomain(Domain domain);
}