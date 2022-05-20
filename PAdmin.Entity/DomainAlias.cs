namespace PAdmin.Entity;

public class DomainAlias
{
    public int DomainAliasId { get; set; }

    public Domain Domain { get; set; } = null!;
    public int DomainId { get; set; }

    public string To { get; set; } = "";
    
    public DateTime CreationDate { get; set; }
    
}