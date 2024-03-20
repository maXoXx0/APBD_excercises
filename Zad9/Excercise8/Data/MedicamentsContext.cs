using Excercise8.Models;
using Excercise9.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Excercise8.Data
{
    public class MedicamentsContext : DbContext
    {
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionsMedicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<User> Users { get; set; }

        public MedicamentsContext(DbContextOptions options) : base(options)
        {
        }

        protected MedicamentsContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("user");
                user.HasKey(e => e.ID);

                user.HasData(new User
                {
                    ID = 1,
                    Login = "maXo",
                    Password = "password"
                });
            });

            modelBuilder.Entity<Medicament>(medicament =>
            {
                medicament.ToTable("Medicament");
                medicament.HasKey(e => e.IdMedicament);

                medicament.Property(e => e.Name).HasMaxLength(100).IsRequired();
                medicament.Property(e => e.Type).HasMaxLength(100).IsRequired();
                medicament.Property(e => e.Description).HasMaxLength(100).IsRequired();

                medicament.HasData(new List<Medicament>() 
                {
                    new Medicament
                    {
                        IdMedicament = 1,
                        Name = "Apap",
                        Description = "paracetamol",
                        Type = "Przeciwbolowy"
                    },
                    new Medicament
                    {
                        IdMedicament = 2,
                        Name = "Aspiryna",
                        Description = "Kwas acetylosalicylowy",
                        Type = "Przeciwzapalny"
                    },
                    new Medicament 
                    { 
                        IdMedicament = 3,
                        Name = "Claritine",
                        Description = "Lotarydyna",
                        Type = "Przeciw alergiczny"
                    }
                });
            });

            modelBuilder.Entity<PrescriptionMedicament>(prescriptionMedicament => 
            {
                prescriptionMedicament.HasKey(e => new { e.IdMedicament, e.IdPrescription });

                prescriptionMedicament.ToTable("Prescription_Medicament");

                prescriptionMedicament.Property(e => e.IdMedicament).IsRequired();
                prescriptionMedicament.Property(e => e.IdPrescription).IsRequired();

                prescriptionMedicament.Property(e => e.Details).HasMaxLength(100).IsRequired();
                prescriptionMedicament.Property(e => e.Details).IsRequired();

                prescriptionMedicament.HasOne(e => e.Prescription)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription)
                .OnDelete(DeleteBehavior.Cascade);

                prescriptionMedicament.HasOne(e => e.Medicament)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament)
                .OnDelete(DeleteBehavior.Cascade);

                prescriptionMedicament.HasData(new List<PrescriptionMedicament>() 
                {
                    new PrescriptionMedicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 2,
                        Dose = 2,
                        Details = "Rano i wieczorem"
                    },
                    new PrescriptionMedicament
                    {
                        IdMedicament = 2,
                        IdPrescription = 3,
                        Dose = 1,
                        Details = "Po kazdym posilku"
                    },
                    new PrescriptionMedicament
                    { 
                        IdMedicament = 3,
                        IdPrescription = 1,
                        Dose = 1,
                        Details = "Przed snem"
                    }
                });
            });

            modelBuilder.Entity<Prescription>(prescription =>
            {
                prescription.HasKey(e => e.IdPrescription);

                prescription.ToTable("Prescription");

                prescription.Property(e => e.Date).IsRequired();
                prescription.Property(e => e.DueDate).IsRequired();

                prescription.HasOne(e => e.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade);

                prescription.HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

                prescription.HasData(new List<Prescription>()
                {
                    new Prescription
                    {
                        IdPrescription = 1,
                        Date = DateTime.Now,
                        DueDate = DateTime.Now,
                        IdDoctor = 1,
                        IdPatient = 3
                    },
                    new Prescription
                    {
                        IdPrescription = 2,
                        Date = DateTime.Now,
                        DueDate= DateTime.Now,
                        IdDoctor = 2,
                        IdPatient = 1
                    },
                    new Prescription
                    {
                        IdPrescription = 3,
                        Date = DateTime.Now,
                        DueDate = DateTime.Now,
                        IdDoctor = 1,
                        IdPatient = 2
                    }
                });
            });

            modelBuilder.Entity<Doctor>(doctor => 
            {
                doctor.HasKey(e => e.IdDoctor);

                doctor.ToTable("Doctor");

                doctor.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                doctor.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                doctor.Property(e => e.Email).HasMaxLength(100).IsRequired();

                doctor.HasData(new List<Doctor>()
                {
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Gregory",
                        LastName = "House",
                        Email = "drhouse@gmail.com"
                    },
                    new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Shoun",
                        LastName = "Murphy",
                        Email = "drmurphy@gmail.com "
                    },
                    new Doctor 
                    { 
                        IdDoctor = 3,
                        FirstName = "Wiktor",
                        LastName = "Frankenstein",
                        Email = "drFrankenshtein@gmail.com"
                    }
                });
            });

            modelBuilder.Entity<Patient>(patient =>
            {
                patient.HasKey(e => e.IdPatient);

                patient.ToTable("Patient");

                patient.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                patient.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                patient.Property(e => e.Birthdate).IsRequired();

                patient.HasData(new List<Patient>()
                {
                    new Patient
                    {
                        IdPatient = 1,
                        FirstName = "Maks",
                        LastName = "Janas",
                        Birthdate = new DateTime(2002, 3, 16)
                    },
                    new Patient
                    {
                        IdPatient = 2,
                        FirstName = "Dwayne",
                        LastName = "Johnson",
                        Birthdate = new DateTime(1972, 5, 2)
                    },
                    new Patient
                    {
                        IdPatient = 3,
                        FirstName = "Son",
                        LastName = "Goku",
                        Birthdate=new DateTime(1982, 4, 18)
                    }
                });
            });

            seed();
        }
        public void seed() { }
    } 
}
