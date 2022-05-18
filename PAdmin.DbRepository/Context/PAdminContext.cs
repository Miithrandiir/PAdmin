using Microsoft.EntityFrameworkCore;
using PAdmin.Entity;

namespace PAdmin.DbRepository.Context;

public class PAdminContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Domain> Domains { get; set; } = null!;
    public DbSet<MailBox> MailBoxes { get; set; } = null!;
    public DbSet<Alias> Aliases { get; set; } = null!;
    public DbSet<DomainAlias> DomainAliases { get; set; } = null!;

    public PAdminContext()
    {
    }

    public PAdminContext(DbContextOptions<PAdminContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(x =>
        {
            x.HasKey(y => y.UserId);
        });
        
        modelBuilder.Entity<Domain>(x =>
        {
            x.HasKey(y => y.DomainId);
            x.HasOne(x => x.User).WithMany(x => x.Domains).HasForeignKey(w => w.UserId);
        });

        modelBuilder.Entity<MailBox>(x =>
        {
            x.HasKey(y => y.MailBoxId);
            x.HasOne(w => w.Domain).WithMany(w => w.MailBoxes).HasForeignKey(w => w.DomainId);
        });

        modelBuilder.Entity<Alias>(x =>
        {
            x.HasKey(w => w.AliasId);
            x.HasOne(w => w.Domain).WithMany(w => w.Aliases).HasForeignKey(w => w.DomainId);
        });

        modelBuilder.Entity<DomainAlias>(x =>
        {
            x.HasKey(w => w.DomainAliasId);
            x.HasOne(w => w.Domain).WithMany(w => w.DomainAliases).HasForeignKey(w => w.DomainId);
        });
    }
}