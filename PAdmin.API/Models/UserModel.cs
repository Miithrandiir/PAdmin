using PAdmin.Entity;

namespace PAdmin.API.Models;

public class UserModel
{
    public int UserId { get; set; }

    public string Email { get; set; } = "";
    
    public string Firstname { get; set; } = "";

    public string Lastname { get; set; } = "";

    public string Roles { get; set; } = "ROLE_USER";
    
    public DateTime? LastConnection { get; set; }
    
    public DateTime? RegisterDate { get; set; }

    public string LastIp { get; set; } = "";

    public string? Token { get; set; } = "";

    public UserModel(User user, string jwt)
    {
        UserId = user.UserId;
        Email = user.Email;
        Firstname = user.Firstname;
        Lastname = user.Lastname;
        Roles = user.Roles;
        LastConnection = user.LastConnection;
        RegisterDate = user.RegisterDate;
        LastIp = user.LastIp;
        Token = jwt;
    }
}