﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RacingCars.Data;

#nullable disable

namespace RacingCars.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20220728102600_NewInitialCreate")]
    partial class NewInitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RacingCars.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Mileage")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarsDb");
                });

            modelBuilder.Entity("RacingCars.Models.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NationalitiesDb");
                });

            modelBuilder.Entity("RacingCars.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("DateOfCompetition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCar")
                        .HasColumnType("int");

                    b.Property<int>("IdPilot")
                        .HasColumnType("int");

                    b.Property<long>("Mileage")
                        .HasColumnType("bigint");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Track")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("IdCar");

                    b.HasIndex("IdPilot");

                    b.ToTable("RacesDb");
                });

            modelBuilder.Entity("RacingCars.VMs.CarVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DateOfService")
                        .HasColumnType("datetime2");

                    b.Property<long>("Mileage")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("CarVM");
                });

            modelBuilder.Entity("RacingCars.VMs.PilotVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PilotsDb");
                });

            modelBuilder.Entity("RacingCars.Models.Race", b =>
                {
                    b.HasOne("RacingCars.Models.Car", null)
                        .WithMany("CarRaces")
                        .HasForeignKey("CarId");

                    b.HasOne("RacingCars.VMs.CarVM", "Car")
                        .WithMany("CarRaces")
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RacingCars.VMs.PilotVM", "Pilot")
                        .WithMany("PilotRaces")
                        .HasForeignKey("IdPilot")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Pilot");
                });

            modelBuilder.Entity("RacingCars.Models.Car", b =>
                {
                    b.Navigation("CarRaces");
                });

            modelBuilder.Entity("RacingCars.VMs.CarVM", b =>
                {
                    b.Navigation("CarRaces");
                });

            modelBuilder.Entity("RacingCars.VMs.PilotVM", b =>
                {
                    b.Navigation("PilotRaces");
                });
#pragma warning restore 612, 618
        }
    }
}