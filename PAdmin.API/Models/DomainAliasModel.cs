namespace PAdmin.API.Models;

public class DomainAliasModel
{
    public int DomainAliasId { get; set; }

    public string To { get; set; } = "";
    
    public DateTime CreationDate { get; set; }
    
}