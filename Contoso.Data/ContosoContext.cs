using Contoso.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Contoso.Data
{
    public class ContosoContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public ContosoContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Users>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<Users>().Property(x => x.CreateDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Users>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Seller>().ToTable("Sellers");
            modelBuilder.Entity<Seller>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<Seller>().Property(x => x.CreateDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Seller>()
                .Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Sale>().ToTable("Sales");
            modelBuilder.Entity<Sale>().Property(s => s.SellerId).IsRequired();
            modelBuilder.Entity<Sale>().Property(s => s.CreateDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Sale>().Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Sale>().HasOne(a => a.Seller)
                .WithMany(u => u.SaleCreated)
                .HasForeignKey(a => a.SellerId);

            modelBuilder.Entity<Operation>().ToTable("Operations");
            modelBuilder.Entity<Operation>().Property(s => s.SellerId).IsRequired();
            modelBuilder.Entity<Operation>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Operation>().Property(s => s.CreateDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Operation>().HasOne(a => a.Seller)
                .WithMany(u => u.OperationCreated)
                .HasForeignKey(a => a.SellerId);

            modelBuilder.Entity<Report>().ToTable("Reports");
            modelBuilder.Entity<Report>().Property(s => s.SellerId).IsRequired();
            modelBuilder.Entity<Report>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Report>().Property(s => s.CreateDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Report>().HasOne(a => a.Seller)
                .WithMany(u => u.Reports)
                .HasForeignKey(a => a.SellerId);
        }

    }
}
