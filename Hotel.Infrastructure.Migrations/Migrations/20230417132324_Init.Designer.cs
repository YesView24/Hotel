﻿// <auto-generated />
using System;
using Hotel.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Infrastructure.Migrations.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20230417132324_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hotel.Domain.Entities.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GuestId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Guest", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Maxim",
                            PhoneNumber = "PhoneNumber 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Denis",
                            PhoneNumber = "PhoneNumber 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Valera",
                            PhoneNumber = "PhoneNumber 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ivan",
                            PhoneNumber = "PhoneNumber 4"
                        });
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReservationId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservation", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2023, 4, 19, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(336),
                            GuestId = 2,
                            RoomId = 3,
                            StartDate = new DateTime(2023, 4, 17, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(319)
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateTime(2023, 4, 20, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(351),
                            GuestId = 3,
                            RoomId = 1,
                            StartDate = new DateTime(2023, 4, 17, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(349)
                        },
                        new
                        {
                            Id = 3,
                            EndDate = new DateTime(2023, 4, 21, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(353),
                            GuestId = 1,
                            RoomId = 2,
                            StartDate = new DateTime(2023, 4, 17, 16, 23, 23, 823, DateTimeKind.Local).AddTicks(353)
                        });
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoomId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Room", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 1,
                            Description = "Room 1a",
                            Number = "1a"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2,
                            Description = "Room 2a",
                            Number = "2a"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 3,
                            Description = "Room 3a",
                            Number = "3a"
                        });
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Hotel.Domain.Entities.Guest", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.Entities.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Guest", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Hotel.Domain.Entities.Room", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
