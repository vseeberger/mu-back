﻿// <auto-generated />
using System;
using AplicacaoEFMysql.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AplicacaoEFMysql.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20210809124924_DbIni")]
    partial class DbIni
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("AplicacaoEFMysql.Models.ShortURL", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("shortUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("id")
                        .HasName("PK_ShortURL");

                    b.ToTable("shorturl");
                });
#pragma warning restore 612, 618
        }
    }
}
