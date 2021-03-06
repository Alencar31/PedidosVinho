﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedidosVinho.Models;

namespace PedidosVinho.Migrations
{
    [DbContext(typeof(PedidosVinhoContext))]
    [Migration("20200425190016_LinhaForeignkey")]
    partial class LinhaForeignkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PedidosVinho.Models.Linha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Linha");
                });

            modelBuilder.Entity("PedidosVinho.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Codigo");

                    b.Property<int>("LinhaId");

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco");

                    b.HasKey("Id");

                    b.HasIndex("LinhaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("PedidosVinho.Models.Produto", b =>
                {
                    b.HasOne("PedidosVinho.Models.Linha", "Linha")
                        .WithMany("Produtos")
                        .HasForeignKey("LinhaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
