using AplicacaoEFMysql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoEFMysql.DBContexts
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region tabela das url's

            modelBuilder.Entity<ShortURL>().ToTable("shorturl");
            modelBuilder.Entity<ShortURL>().HasKey(u => u.id).HasName("PK_ShortURL");
            modelBuilder.Entity<ShortURL>().Property(u => u.id).HasColumnType("bigint").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<ShortURL>().Property(u => u.url).HasColumnType("nvarchar(250)").IsRequired();
            modelBuilder.Entity<ShortURL>().Property(u => u.shortUrl).HasColumnType("nvarchar(250)").IsRequired();
            modelBuilder.Entity<ShortURL>().Property(u => u.Created_at).HasColumnType("datetime").IsRequired();

            #endregion
        }

        public DbSet<ShortURL> ShortURLs { get; set; }
    }
}
