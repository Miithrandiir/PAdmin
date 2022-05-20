using System.ComponentModel.DataAnnotations;

namespace PAdmin.API.Forms;

public class DomainForm
{
    [Required]
    public string Name { get; set; }
    public bool IsActive { get; set; }
}