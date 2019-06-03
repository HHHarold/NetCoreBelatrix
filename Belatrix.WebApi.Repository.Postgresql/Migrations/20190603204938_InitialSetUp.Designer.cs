﻿// <auto-generated />
using System;
using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.WebApi.Repository.Postgresql.Migrations
{
    [DbContext(typeof(BelatrixDbContext))]
    [Migration("20190603204938_InitialSetUp")]
    partial class InitialSetUp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Belatrix.WebApi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasMaxLength(40);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(40);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("LastName", "FirstName")
                        .HasName("customer_name_idx");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("order_date");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnName("order_number")
                        .HasMaxLength(10);

                    b.Property<decimal?>("TotalAmount")
                        .IsRequired()
                        .HasColumnName("total_amount")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Id")
                        .HasName("order_id_idx");

                    b.HasIndex("OrderDate")
                        .HasName("order_order_date_idx");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("unit_price")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("order_item_id_idx");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId")
                        .HasName("order_item_product_id_idx");

                    b.ToTable("order_item");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDiscontinued")
                        .HasColumnName("is_idscontinued");

                    b.Property<string>("Package")
                        .IsRequired()
                        .HasColumnName("package")
                        .HasMaxLength(30);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("product_name")
                        .HasMaxLength(50);

                    b.Property<int>("SupplierId")
                        .HasColumnName("supplier_id");

                    b.Property<decimal?>("UnitPrice")
                        .IsRequired()
                        .HasColumnName("unit_price")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductName")
                        .HasName("product_product_name_idx");

                    b.HasIndex("SupplierId")
                        .HasName("product_supplier_id_idx");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasMaxLength(40);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("company_name")
                        .HasMaxLength(40);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnName("contact_name")
                        .HasMaxLength(50);

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnName("contact_title")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasMaxLength(40);

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnName("fax")
                        .HasMaxLength(30);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("CompanyName")
                        .HasName("supplier_company_name_idx");

                    b.HasIndex("Country")
                        .HasName("supplier_country_idx");

                    b.ToTable("supplier");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Order", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Customer", "CustomerNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("order_customer_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.OrderItem", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Order", "OrderNavigation")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("order_item_order_id_fkey")
                        .IsRequired();

                    b.HasOne("Belatrix.WebApi.Models.Product", "ProductNavigation")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("order_item_product_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Product", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Supplier", "SupplierNavigation")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("product_supplier_id_fkey")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
