using System.ComponentModel.DataAnnotations;

namespace PAdmin.API.Forms;

public class UserForm
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
    
    [Required]
    public string Firstname { get; set; } = "";

    [Required]
    public string Lastname { get; set; } = "";

    [Required]
    [MinLength(8)]
    public string Password { get; set; } = "";
}