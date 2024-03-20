﻿// <auto-generated />
using System;
using Excercise8.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Excercise8.Migrations
{
    [DbContext(typeof(MedicamentsContext))]
    partial class MedicamentsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Excercise8.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctor", (string)null);

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "drhouse@gmail.com",
                            FirstName = "Gregory",
                            LastName = "House"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "drmurphy@gmail.com ",
                            FirstName = "Shoun",
                            LastName = "Murphy"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "drFrankenshtein@gmail.com",
                            FirstName = "Wiktor",
                            LastName = "Frankenstein"
                        });
                });

            modelBuilder.Entity("Excercise8.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicament", (string)null);

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "paracetamol",
                            Name = "Apap",
                            Type = "Przeciwbolowy"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Kwas acetylosalicylowy",
                            Name = "Aspiryna",
                            Type = "Przeciwzapalny"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Lotarydyna",
                            Name = "Claritine",
                            Type = "Przeciw alergiczny"
                        });
                });

            modelBuilder.Entity("Excercise8.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patient", (string)null);

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(2002, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Maks",
                            LastName = "Janas"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Dwayne",
                            LastName = "Johnson"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(1982, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Son",
                            LastName = "Goku"
                        });
                });

            modelBuilder.Entity("Excercise8.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription", (string)null);

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7290),
                            DueDate = new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7332),
                            IdDoctor = 1,
                            IdPatient = 3
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7337),
                            DueDate = new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7338),
                            IdDoctor = 2,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7341),
                            DueDate = new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7343),
                            IdDoctor = 1,
                            IdPatient = 2
                        });
                });

            modelBuilder.Entity("Excercise8.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicament", (string)null);

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 2,
                            Details = "Rano i wieczorem",
                            Dose = 2
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 3,
                            Details = "Po kazdym posilku",
                            Dose = 1
                        },
                        new
                        {
                            IdMedicament = 3,
                            IdPrescription = 1,
                            Details = "Przed snem",
                            Dose = 1
                        });
                });

            modelBuilder.Entity("Excercise8.Models.Prescription", b =>
                {
                    b.HasOne("Excercise8.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Excercise8.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Excercise8.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("Excercise8.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Excercise8.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Excercise8.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Excercise8.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("Excercise8.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Excercise8.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
