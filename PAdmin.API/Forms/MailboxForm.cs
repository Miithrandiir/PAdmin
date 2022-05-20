using System.ComponentModel.DataAnnotations;

namespace PAdmin.API.Forms;

public class MailboxForm
{
    [Required, MaxLength(30)] public string Name { get; set; } = "";

    [Required] public int DomainId { get; set; } = 0;

    public int Quota { get; set; } = 0;
}