using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Moq;
using PAdmin.Business;
using PAdmin.Entity;
using Xunit;
using IConfiguration = Castle.Core.Configuration.IConfiguration;

namespace PAdmin.Test.Services;

public class AuthServiceTest
{
    private readonly AuthService _authService;

    public AuthServiceTest()
    {
        var inMemorySettings = new Dictionary<string, string>()
        {
            {"JWT:secret", "blablablablablablablabalbalbal"},
            {"JWT:expiration_hour", "1"},
        };

        IConfigurationRoot configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
        var passwordHash = new PasswordHashService();
        
        _authService = new AuthService(passwordHash, configuration);
    }

    [Fact]
    public async Task EnsureJwtCreation()
    {
        string test = await _authService.Login(new User(){UserId = 1, Email = "simon@heban.fr", Roles = "Dev", Firstname = "Simon", Lastname = "Heban"});
        Assert.NotEmpty(test);
    }
}