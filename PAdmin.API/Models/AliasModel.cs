namespace PAdmin.API.Models;

public class AliasModel
{
    public int AliasId { get; set; }

    public string From { get; set; } = "";
    public string To { get; set; } = "";

    public DateTime CreationDate { get; set; }
}