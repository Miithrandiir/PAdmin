using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using PAdmin.Entity;

namespace PAdmin.API.Models;

public class MailBoxModel : RefModel
{
    public int MailBoxId { get; set; }
    public string Name { get; set; } = "";
    
    public int DomainId { get; set; }
    
    public int Quota { get; set; }

    public MailBoxModel(MailBox mailBox, IUrlHelper url)
    {
        MailBoxId = mailBox.MailBoxId;
        Name = mailBox.Name;
        DomainId = mailBox.DomainId;
        Quota = mailBox.Quota;
        Refs.Add("domain", url.Action("GetById", "Domain", mailBox.DomainId)!);
    }
}