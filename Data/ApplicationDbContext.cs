using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolSmukfest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            //builder.Entity<Post>()
            //    .HasOne(x => x.CurrentVersion)
            //    .WithOne(x => x.Post);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembaOrder>()
                        .HasOne(m => m.Member)
                        .WithMany(t => t.MembaOrders)
                        .HasForeignKey(m => m.MemberId)
                        .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<MembaOrder>()
                        .HasOne(m => m.CreatedByMember)
                        .WithMany(t => t.MembaOrdersCreated)
                        .HasForeignKey(m => m.CreatedByMemberId)
                        .OnDelete(DeleteBehavior.Restrict);
                        

            modelBuilder.Entity<Item>()
                        .HasOne(m => m.ReceiverMember)
                        .WithMany(t => t.ItemsReceived)
                        .HasForeignKey(m => m.ReceiverMemberId)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Item>()
                        .HasOne(m => m.ReturnerMember)
                        .WithMany(t => t.ItemsReturned)
                        .HasForeignKey(m => m.ReturnerMemberId)
                        .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<ToolSmukfest.Models.Project> Projects { get; set; }
        public DbSet<ToolSmukfest.Models.Event> Events { get; set; }

        public DbSet<ToolSmukfest.Models.Team> Teams { get; set; }

        public DbSet<ToolSmukfest.Models.Member> Members { get; set; }

        public DbSet<ToolSmukfest.Models.Section> Section { get; set; }

        public DbSet<ToolSmukfest.Models.Festival> Festival { get; set; }

        public DbSet<ToolSmukfest.Models.ItemType> ItemType { get; set; }

        public DbSet<ToolSmukfest.Models.MembaOrder> MembaOrders { get; set; }

        public DbSet<ToolSmukfest.Models.MembaOrderLine> MembaOrderLines { get; set; }
    }
}
