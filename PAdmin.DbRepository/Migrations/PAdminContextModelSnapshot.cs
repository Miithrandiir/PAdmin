﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PAdmin.DbRepository.Context;

#nullable disable

namespace PAdmin.DbRepository.Migrations
{
    [DbContext(typeof(PAdminContext))]
    partial class PAdminContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PAdmin.Entity.Alias", b =>
                {
                    b.Property<int>("AliasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AliasId");

                    b.HasIndex("DomainId");

                    b.ToTable("Aliases", (string)null);
                });

            modelBuilder.Entity("PAdmin.Entity.Domain", b =>
                {
                    b.Property<int>("DomainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DomainName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DomainId");

                    b.HasIndex("UserId");

                    b.ToTable("Domains", (string)null);
                });

            modelBuilder.Entity("PAdmin.Entity.DomainAlias", b =>
                {
                    b.Property<int>("DomainAliasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DomainAliasId");

                    b.HasIndex("DomainId");

                    b.ToTable("DomainAliases", (string)null);
                });

            modelBuilder.Entity("PAdmin.Entity.MailBox", b =>
                {
                    b.Property<int>("MailBoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.HasKey("MailBoxId");

                    b.HasIndex("DomainId");

                    b.ToTable("MailBoxes", (string)null);
                });

            modelBuilder.Entity("PAdmin.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastConnection")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastIp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("RegisterDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PAdmin.Entity.Alias", b =>
                {
                    b.HasOne("PAdmin.Entity.Domain", "Domain")
                        .WithMany("Aliases")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("PAdmin.Entity.Domain", b =>
                {
                    b.HasOne("PAdmin.Entity.User", "User")
                        .WithMany("Domains")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PAdmin.Entity.DomainAlias", b =>
                {
                    b.HasOne("PAdmin.Entity.Domain", "Domain")
                        .WithMany("DomainAliases")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("PAdmin.Entity.MailBox", b =>
                {
                    b.HasOne("PAdmin.Entity.Domain", "Domain")
                        .WithMany("MailBoxes")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("PAdmin.Entity.Domain", b =>
                {
                    b.Navigation("Aliases");

                    b.Navigation("DomainAliases");

                    b.Navigation("MailBoxes");
                });

            modelBuilder.Entity("PAdmin.Entity.User", b =>
                {
                    b.Navigation("Domains");
                });
#pragma warning restore 612, 618
        }
    }
}
