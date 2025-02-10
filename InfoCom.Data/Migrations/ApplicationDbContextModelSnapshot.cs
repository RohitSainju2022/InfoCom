﻿// <auto-generated />
using System;
using InfoCom.Data.InfoComDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfoCom.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InfoCom.Model.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasAnnotation("DefaultValue", "false");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "I am Demo description",
                            DueDate = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Status = "BackLog",
                            Title = "DemoTitle"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "I am Demo description two",
                            DueDate = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Status = "ToDO",
                            Title = "DemoTitle2"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "I am Demo description three",
                            DueDate = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Status = "InProgress",
                            Title = "DemoTiTle3"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "I am Demo description four",
                            DueDate = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Status = "Reviewing",
                            Title = "DemoTiTle4"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "I am Demo description five",
                            DueDate = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Status = "Revieving",
                            Title = "DemoTiTle5"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "I am Demo description six",
                            DueDate = new DateTime(2025, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Status = "QATesting",
                            Title = "DemoTiTle6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
