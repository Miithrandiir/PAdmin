namespace PAdmin.Entity;

public class Domain
{
    public int DomainId { get; set; }
    public string DomainName { get; set; } = "";
    public User? User { get; set; }
    public int? UserId { get; set; }
    
    public List<MailBox> MailBoxes { get; set; }
    public List<Alias> Aliases { get; set; }
    public List<DomainAlias> DomainAliases { get; set; }
    
    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }
}