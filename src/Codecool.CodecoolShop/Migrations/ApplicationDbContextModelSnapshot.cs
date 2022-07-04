﻿// <auto-generated />
using System;
using Codecool.CodecoolShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Codecool.CodecoolShop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Codecool.CodecoolShop.Models.BaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BaseModels");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseModel");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Product", b =>
                {
                    b.HasBaseType("Codecool.CodecoolShop.Models.BaseModel");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DefaultPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("SupplierId");

                    b.HasDiscriminator().HasValue("Product");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.ProductCategory", b =>
                {
                    b.HasBaseType("Codecool.CodecoolShop.Models.BaseModel");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ProductCategory");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Supplier", b =>
                {
                    b.HasBaseType("Codecool.CodecoolShop.Models.BaseModel");

                    b.HasDiscriminator().HasValue("Supplier");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Product", b =>
                {
                    b.HasOne("Codecool.CodecoolShop.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId");

                    b.HasOne("Codecool.CodecoolShop.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("ProductCategory");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Codecool.CodecoolShop.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}