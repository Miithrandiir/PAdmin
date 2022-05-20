using Microsoft.Extensions.DependencyInjection;
using PAdmin.Core.DbRepository;
using PAdmin.DbRepository.Repository;

namespace PAdmin.DbRepository;

public static class RegisterRepository
{
    public static void AddRepositoryToScoped(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IDomainRepository, DomainRepository>();
    }
}