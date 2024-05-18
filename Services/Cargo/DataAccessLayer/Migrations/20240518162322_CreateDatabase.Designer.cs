﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(DapperContext))]
    [Migration("20240518162322_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Entities.CargoCompany", b =>
                {
                    b.Property<int>("company_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("company_id"));

                    b.Property<string>("company_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("company_id");

                    b.ToTable("cargo_company");
                });

            modelBuilder.Entity("EntityLayer.Entities.CargoCustomer", b =>
                {
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("customer_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("customer_id");

                    b.ToTable("cargo_customer");
                });

            modelBuilder.Entity("EntityLayer.Entities.CargoDetail", b =>
                {
                    b.Property<int>("detail_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("detail_id"));

                    b.Property<string>("barcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("company_id")
                        .HasColumnType("integer");

                    b.Property<string>("receiver_customer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("sender_customer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("detail_id");

                    b.ToTable("cargo_detail");
                });

            modelBuilder.Entity("EntityLayer.Entities.CargoOperation", b =>
                {
                    b.Property<int>("operation_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("operation_id"));

                    b.Property<string>("barcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("operation_date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("operation_id");

                    b.ToTable("cargo_operation");
                });
#pragma warning restore 612, 618
        }
    }
}
