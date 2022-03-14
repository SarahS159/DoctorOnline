﻿// <auto-generated />
using System;
using DoctorOnline_Dashboard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoctorOnline_Dashboard.Migrations
{
    [DbContext(typeof(DoctorOnlineContext))]
    [Migration("20220217105037_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.ConsultantOrder", b =>
                {
                    b.Property<int>("consultantOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("consultantCost")
                        .HasColumnType("int");

                    b.Property<DateTime>("consultantDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("consultantStatus")
                        .HasColumnType("int");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("specialityId")
                        .HasColumnType("int");

                    b.HasKey("consultantOrderId");

                    b.HasIndex("patientId");

                    b.HasIndex("specialityId");

                    b.ToTable("ConsultantOrders");
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.Doctor", b =>
                {
                    b.Property<int>("doctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("doctorAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctorCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctorGsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctorPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctorSchedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctorSpeciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("specialityId")
                        .HasColumnType("int");

                    b.HasKey("doctorId");

                    b.HasIndex("specialityId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.Medicament", b =>
                {
                    b.Property<int>("medicamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("medicamentCost")
                        .HasColumnType("int");

                    b.Property<int>("medicamentCount")
                        .HasColumnType("int");

                    b.Property<string>("medicamentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medicamentSchedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("medicamentId");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.Patient", b =>
                {
                    b.Property<int>("patientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("isActive")
                        .HasColumnType("int");

                    b.Property<int>("patientAge")
                        .HasColumnType("int");

                    b.Property<string>("patientCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patientGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patientGsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patientPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("verificationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("patientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.Patient_Doctor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("doctorId")
                        .HasColumnType("int");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("doctorId");

                    b.HasIndex("patientId");

                    b.ToTable("Patients_Doctors");
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.Speciality", b =>
                {
                    b.Property<int>("specialityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("specialityDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("specialityTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("specialityId");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.Ticket", b =>
                {
                    b.Property<int>("ticketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<string>("ticketDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ticketId");

                    b.HasIndex("patientId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.ConsultantOrder", b =>
                {
                    b.HasOne("DoctorOnline_Dashboard.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorOnline_Dashboard.Models.Speciality", "speciality")
                        .WithMany()
                        .HasForeignKey("specialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.Doctor", b =>
                {
                    b.HasOne("DoctorOnline_Dashboard.Models.Speciality", "speciality")
                        .WithMany()
                        .HasForeignKey("specialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.Patient_Doctor", b =>
                {
                    b.HasOne("DoctorOnline_Dashboard.Models.Doctor", "doctor")
                        .WithMany()
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorOnline_Dashboard.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorOnline_Dashboard.Models.Ticket", b =>
                {
                    b.HasOne("DoctorOnline_Dashboard.Models.Patient", "patient")
                        .WithMany()
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
