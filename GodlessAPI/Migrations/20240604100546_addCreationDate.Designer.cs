﻿// <auto-generated />
using System;
using GodlessAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GodlessAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240604100546_addCreationDate")]
    partial class addCreationDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GodlessAPI.Models.Godless", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Creation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Creation = new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5277),
                            Name = "Product A"
                        },
                        new
                        {
                            Id = 2,
                            Creation = new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5330),
                            Name = "Thor"
                        },
                        new
                        {
                            Id = 3,
                            Creation = new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5332),
                            Name = "Odin A"
                        },
                        new
                        {
                            Id = 4,
                            Creation = new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5334),
                            Name = "Thanos A"
                        },
                        new
                        {
                            Id = 5,
                            Creation = new DateTime(2024, 6, 4, 12, 5, 45, 800, DateTimeKind.Local).AddTicks(5335),
                            Name = "Julius A"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
