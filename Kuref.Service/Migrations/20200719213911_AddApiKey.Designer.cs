﻿// <auto-generated />
using System;
using Kuref.Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kuref.Service.Migrations
{
    [DbContext(typeof(KurefContext))]
    [Migration("20200719213911_AddApiKey")]
    partial class AddApiKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Kuref.Service.Models.ApiKey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.ToTable("ApiKeys");
                });

            modelBuilder.Entity("Kuref.Service.Models.DeviceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("Kuref.Service.Models.Measurement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("MeasurementTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MeasurementTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementTypeId");

                    b.HasIndex("StationId");

                    b.ToTable("Measurement");
                });

            modelBuilder.Entity("Kuref.Service.Models.MeasurementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MeasurementUnit")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("MeasurementTypes");
                });

            modelBuilder.Entity("Kuref.Service.Models.PhysicalDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Manufacter")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Model")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("PhysicalDevices");
                });

            modelBuilder.Entity("Kuref.Service.Models.PhysicalDeviceAssignation", b =>
                {
                    b.Property<int>("MeasurementTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("PhysicalDeviceId")
                        .HasColumnType("integer");

                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.HasKey("MeasurementTypeId", "PhysicalDeviceId", "StationId");

                    b.HasIndex("PhysicalDeviceId")
                        .IsUnique();

                    b.HasIndex("StationId");

                    b.ToTable("PhysicalDeviceAssignations");
                });

            modelBuilder.Entity("Kuref.Service.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Altitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<string>("LocationDescription")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Kuref.Service.Models.Measurement", b =>
                {
                    b.HasOne("Kuref.Service.Models.MeasurementType", "MeasurementType")
                        .WithMany("Measurements")
                        .HasForeignKey("MeasurementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kuref.Service.Models.Station", "Station")
                        .WithMany("Measurements")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kuref.Service.Models.PhysicalDevice", b =>
                {
                    b.HasOne("Kuref.Service.Models.DeviceType", "DeviceType")
                        .WithMany("PhysicalDevices")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kuref.Service.Models.PhysicalDeviceAssignation", b =>
                {
                    b.HasOne("Kuref.Service.Models.MeasurementType", "MeasurementType")
                        .WithMany()
                        .HasForeignKey("MeasurementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kuref.Service.Models.PhysicalDevice", "PhysicalDevice")
                        .WithOne("PhysicalDeviceAssignation")
                        .HasForeignKey("Kuref.Service.Models.PhysicalDeviceAssignation", "PhysicalDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kuref.Service.Models.Station", "Station")
                        .WithMany("PhysicalDeviceAssignations")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
