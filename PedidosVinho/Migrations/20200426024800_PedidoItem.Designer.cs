﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedidosVinho.Models;

namespace PedidosVinho.Migrations
{
    [DbContext(typeof(PedidosVinhoContext))]
    [Migration("20200426024800_PedidoItem")]
    partial class PedidoItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PedidosVinho.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PedidosVinho.Models.Linha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Linha");
                });

            modelBuilder.Entity("PedidosVinho.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("DataPedido");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("PedidosVinho.Models.PedidoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PedidoId");

                    b.Property<int>("Quantidade");

                    b.Property<decimal>("ValorTotal");

                    b.Property<decimal>("ValorUnitario");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("PedidosVinho.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Codigo");

                    b.Property<int>("LinhaId");

                    b.Property<string>("Nome");

                    b.Property<int?>("PedidoItemId");

                    b.Property<decimal>("Preco");

                    b.HasKey("Id");

                    b.HasIndex("LinhaId");

                    b.HasIndex("PedidoItemId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("PedidosVinho.Models.Pedido", b =>
                {
                    b.HasOne("PedidosVinho.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PedidosVinho.Models.PedidoItem", b =>
                {
                    b.HasOne("PedidosVinho.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PedidosVinho.Models.Produto", b =>
                {
                    b.HasOne("PedidosVinho.Models.Linha", "Linha")
                        .WithMany("Produtos")
                        .HasForeignKey("LinhaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PedidosVinho.Models.PedidoItem")
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoItemId");
                });
#pragma warning restore 612, 618
        }
    }
}
