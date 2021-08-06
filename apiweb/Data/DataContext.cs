using apiweb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiweb.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Password=retl@v85;Persist Security Info=True;User ID=vsee;Initial Catalog=lefv1_ecom;Data Source=144.217.254.145\MSSQLSERVER2012,11433");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => new { e.Item });
            });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItems> OrderItems { get; set; }
    }
}
