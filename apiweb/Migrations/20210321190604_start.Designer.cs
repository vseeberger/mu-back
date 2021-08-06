﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiweb.Data;

namespace apiweb.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210321190604_start")]
    partial class start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apiweb.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BAtivo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DtmCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("SAldeia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("apiweb.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BAtivo")
                        .HasColumnType("bit");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("DDesconto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DValorPedido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DtmCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmPedido")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("apiweb.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Item")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ProductValorUn")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "Item");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("apiweb.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BAtivo")
                        .HasColumnType("bit");

                    b.Property<decimal>("DValor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DtmCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SPathFoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("apiweb.Models.OrderItems", b =>
                {
                    b.HasOne("apiweb.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
