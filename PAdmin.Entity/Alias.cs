namespace PAdmin.Entity;

public class Alias
{
    public int AliasId { get; set; }

    public string From { get; set; } = "";
    public string To { get; set; } = "";

    public Domain Domain { get; set; } = null!;
    public int DomainId { get; set; }
    
    public DateTime CreationDate { get; set; }
}