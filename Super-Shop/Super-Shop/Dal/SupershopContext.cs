using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Super_Shop.Entities;
using Super_Shop.Models;

#nullable disable

namespace Super_Shop.Dal
{
    public partial class SupershopContext : DbContext
    {
        //public SupershopContext()
        //{
        //    /// Update-Database -Migration 0
        //    /// Remove-Migration
        //    /// 
        //}

        public SupershopContext(DbContextOptions<SupershopContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Supershop;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            OnModelCreatingPartial(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new HeroConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new ContactFormRequestConfiguration());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        /// <summary>
        /// DbSets
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ContactFormRequest> ContactFormRequests { get; set; }
    }
}
