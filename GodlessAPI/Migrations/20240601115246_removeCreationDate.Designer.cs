﻿// <auto-generated />
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
    [Migration("20240601115246_removeCreationDate")]
    partial class removeCreationDate
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Product A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Thor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Odin A"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Thanos A"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Julius A"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
