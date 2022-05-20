using Microsoft.AspNetCore.Mvc;
using PAdmin.Entity;

namespace PAdmin.API.Models;

public class DomainModel : RefModel
{
    public int DomainId { get; set; }

    public string DomainName { get; set; }

    public List<MailBoxModel> MailBoxes { get; set; }
    public List<AliasModel> Aliases { get; set; }
    public List<DomainAliasModel> DomainAliases { get; set; }

    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }

    public DomainModel(Domain domain, IUrlHelper url)
    {
        DomainId = domain.DomainId;
        DomainName = domain.DomainName;
        CreationDate = domain.CreationDate;
        IsActive = domain.IsActive;
        if (domain.MailBoxes != null)
        {
            MailBoxes = domain.MailBoxes.ConvertAll(x => new MailBoxModel(x, url));
        }

        Refs = new Dictionary<string, string>();
        Refs.Add("get", "http://test.fr");
    }
}