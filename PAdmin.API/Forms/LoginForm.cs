using System.ComponentModel.DataAnnotations;

namespace PAdmin.API.Forms;

public class LoginForm
{
    [Required, EmailAddress]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
}