namespace PAdmin.Entity;

public class DomainAlias
{
    public int DomainAliasId { get; set; }

    public Domain Domain { get; set; } = new Domain();
    public int DomainId { get; set; }

    public string To { get; set; } = "";
    
    public DateTime CreationDate { get; set; }
    
}