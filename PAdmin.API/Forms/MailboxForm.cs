namespace PAdmin.API.Forms;

public class MailboxForm
{
    public string Name { get; set; } = "";
    public int DomainId { get; set; }
    public int Quota { get; set; }
}