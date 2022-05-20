using System.Threading.Tasks;
using PAdmin.Business;
using Xunit;

namespace PAdmin.Test.Services;

public class PasswordHashTest
{
    private readonly PasswordHashService _passwordHashService;
    
    public PasswordHashTest()
    {
        _passwordHashService = new PasswordHashService();
    }

    [Fact]
    public void AbleToHash()
    {
        Assert.NotNull(_passwordHashService.HashPassword("patate"));
    }

    [Fact]
    public async Task AbleToConfirm()
    {
        string hash = await _passwordHashService.HashPassword("patate");
        Assert.True(await _passwordHashService.ComparePassword("patate", hash));
        Assert.False(await _passwordHashService.ComparePassword("WRONG", hash));
        
    }
}