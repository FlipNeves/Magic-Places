﻿// <auto-generated />
using System;
using MagicPlaces_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicPlaces_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230511024817_startingMyDataBase")]
    partial class startingMyDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MagicPlaces_API.Models.Places", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Você paga pelo local, lindo. Não pela comida.",
                            CreatedDate = new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3666),
                            Details = "Um restaurante tematizado ao estilo medieval.",
                            LastDate = new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3675),
                            Location = "St. Bueno. T2",
                            Name = "Tavernna",
                            Rate = 8.4000000000000004
                        },
                        new
                        {
                            Id = 2,
                            Comment = "A comida está mais do que aprovada.",
                            CreatedDate = new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3676),
                            Details = "Um bom local para uma bebida.",
                            LastDate = new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3676),
                            Location = "St. Bela Vista",
                            Name = "OFFICINA",
                            Rate = 8.5
                        },
                        new
                        {
                            Id = 3,
                            Comment = "A comida e atendimento são exemplares. Ótimo local.",
                            CreatedDate = new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3677),
                            Details = "Um restaurante/sanduicheria muito gostosa.",
                            LastDate = new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3677),
                            Location = "Próximo ao Flamboyant Shopping",
                            Name = "LIFE BOX",
                            Rate = 9.1999999999999993
                        });
                });

            modelBuilder.Entity("MagicPlaces_API.Models.PlacesNumber", b =>
                {
                    b.Property<int>("PlaceNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PlaceNo");

                    b.ToTable("PlacesNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
