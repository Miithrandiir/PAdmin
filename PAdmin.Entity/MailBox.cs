namespace PAdmin.Entity;

public class MailBox
{
    public int MailBoxId { get; set; }
    public string Name { get; set; } = "";
    public Domain Domain { get; set; } = null!;
    public int DomainId { get; set; }
    
    public int Quota { get; set; }
}