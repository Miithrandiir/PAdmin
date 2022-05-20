using Microsoft.Extensions.DependencyInjection;
using PAdmin.Core.Business;

namespace PAdmin.Business;

public static class RegisterServices
{
    public static void AddServiceToScoped(this IServiceCollection service)
    {
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<IPasswordHashService, PasswordHashService>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IDomainService, DomainService>();
        service.AddScoped<IMailboxService, MailboxService>();
    }
}