﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingApi.Data;

namespace ShoppingApi.Migrations
{
    [DbContext(typeof(ShoppingDataContext))]
    [Migration("20200505170219_Curbside")]
    partial class Curbside
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingApi.Data.OrderForCurbside", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("For")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Items")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CurbsideOrders");
                });

            modelBuilder.Entity("ShoppingApi.Data.ShoppingItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Purchased")
                        .HasColumnType("bit");

                    b.Property<string>("PurchasedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchasedFrom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShoppingItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Beer",
                            Purchased = false
                        },
                        new
                        {
                            Id = 2,
                            Description = "Toilet Paper",
                            Purchased = true,
                            PurchasedFrom = "Acme"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
