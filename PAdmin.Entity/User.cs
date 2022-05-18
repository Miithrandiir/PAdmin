namespace PAdmin.Entity;

public class User
{
    public int UserId { get; set; }

    public string Firstname { get; set; } = "";

    public string Lastname { get; set; } = "";

    public string Password { get; set; } = "";

    public string Roles { get; set; } = "";
    
    public DateTime? LastConnection { get; set; }
    
    public DateTime? RegisterDate { get; set; }

    public string LastIp { get; set; } = "";
    
    public List<Domain> Domains { get; set; }
}