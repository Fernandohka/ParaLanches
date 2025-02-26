﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Entities;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ParaLanchesDbContext))]
    [Migration("20250226141111_pedido")]
    partial class pedido
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BebidaOrder", b =>
                {
                    b.Property<Guid>("BebidasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BebidasId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("BebidaOrder");
                });

            modelBuilder.Entity("IngredienteLanche", b =>
                {
                    b.Property<Guid>("IngredientesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LancheId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngredientesId", "LancheId");

                    b.HasIndex("LancheId");

                    b.ToTable("IngredienteLanche");
                });

            modelBuilder.Entity("LancheOrder", b =>
                {
                    b.Property<Guid>("LanchesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LanchesId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("LancheOrder");
                });

            modelBuilder.Entity("Server.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InvitedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvitedById");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Server.Entities.Pedido.Bebida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Bebidas");
                });

            modelBuilder.Entity("Server.Entities.Pedido.Ingrediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LancheId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("LancheId");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("Server.Entities.Pedido.Lanche", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Lanches");
                });

            modelBuilder.Entity("Server.Entities.Pedido.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Server.Entities.Pedido.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BebidaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LancheId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BebidaId");

                    b.HasIndex("ClientId");

                    b.HasIndex("LancheId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BebidaOrder", b =>
                {
                    b.HasOne("Server.Entities.Pedido.Bebida", null)
                        .WithMany()
                        .HasForeignKey("BebidasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.Pedido.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IngredienteLanche", b =>
                {
                    b.HasOne("Server.Entities.Pedido.Ingrediente", null)
                        .WithMany()
                        .HasForeignKey("IngredientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.Pedido.Lanche", null)
                        .WithMany()
                        .HasForeignKey("LancheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LancheOrder", b =>
                {
                    b.HasOne("Server.Entities.Pedido.Lanche", null)
                        .WithMany()
                        .HasForeignKey("LanchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.Pedido.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Server.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Server.Entities.ApplicationUser", "InvitedBy")
                        .WithMany("InvitedUsers")
                        .HasForeignKey("InvitedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("InvitedBy");
                });

            modelBuilder.Entity("Server.Entities.Pedido.Ingrediente", b =>
                {
                    b.HasOne("Server.Entities.Pedido.Lanche", null)
                        .WithMany("Adicionais")
                        .HasForeignKey("LancheId");
                });

            modelBuilder.Entity("Server.Entities.Pedido.Order", b =>
                {
                    b.HasOne("Server.Entities.ApplicationUser", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Server.Entities.Pedido.Review", b =>
                {
                    b.HasOne("Server.Entities.Pedido.Bebida", "Bebida")
                        .WithMany()
                        .HasForeignKey("BebidaId");

                    b.HasOne("Server.Entities.ApplicationUser", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.Pedido.Lanche", "Lanche")
                        .WithMany()
                        .HasForeignKey("LancheId");

                    b.Navigation("Bebida");

                    b.Navigation("Client");

                    b.Navigation("Lanche");
                });

            modelBuilder.Entity("Server.Entities.ApplicationUser", b =>
                {
                    b.Navigation("InvitedUsers");
                });

            modelBuilder.Entity("Server.Entities.Pedido.Lanche", b =>
                {
                    b.Navigation("Adicionais");
                });
#pragma warning restore 612, 618
        }
    }
}
