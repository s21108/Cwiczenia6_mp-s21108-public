using Microsoft.EntityFrameworkCore;
using System;

namespace Cwiczenia6_mp_s21108.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(e => e.IdDoctor);
                d.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                d.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                d.Property(e => e.Email).IsRequired().HasMaxLength(100);

                d.HasData(
                    new Doctor { IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jankowalski@gmail.com" },
                    new Doctor { IdDoctor = 2, FirstName = "Adam", LastName = "Nowak", Email = "adamnowak@gmail.com"}
                    );
            });

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.IdPatient);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.Birthdate).IsRequired();

                p.HasData(
                    new Patient { IdPatient = 1, FirstName = "Adam", LastName = "Kowalski", Birthdate = DateTime.Parse("1973-05-04")},
                    new Patient { IdPatient = 2, FirstName = "Jan", LastName = "Nowak", Birthdate = DateTime.Parse("1999-01-01")}
                    );
            });

            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.Property(e => e.Date).IsRequired();
                p.Property(e => e.DueDate).IsRequired();

                p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                p.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);

                p.HasData(
                    new Prescription { IdPrescription = 1, Date = DateTime.Parse("2022-01-01"), DueDate = DateTime.Parse("2022-03-01"), IdDoctor = 1, IdPatient = 2},
                    new Prescription { IdPrescription = 2, Date = DateTime.Parse("2022-02-02"), DueDate = DateTime.Parse("2022-03-03"), IdDoctor = 2, IdPatient = 1}
                    );
            });

            modelBuilder.Entity<Medicament>(m =>
            {
                m.HasKey(e => e.IdMedicament);
                m.Property(e => e.Name).IsRequired().HasMaxLength(100);
                m.Property(e => e.Description).IsRequired().HasMaxLength(100);
                m.Property(e => e.Type).IsRequired().HasMaxLength(100);

                m.HasData(
                    new Medicament { IdMedicament = 1, Name = "Tabletki na ból głowy", Description = "Pomagają z bólem głowy", Type = "Tabletki"},
                    new Medicament { IdMedicament = 2, Name = "Parametanol", Description = "Lek przeciwbólowy", Type = "Tabletki"}
                    );
            });

            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasKey(e => new
                {
                    e.IdMedicament, e.IdPrescription   
                });
                p.Property(e => e.Details).IsRequired().HasMaxLength(100);
                p.HasOne(e => e.Medicament).WithMany(e => e.Prescription_Medicaments).HasForeignKey(e => e.IdMedicament);
                p.HasOne(e => e.Prescription).WithMany(e => e.Prescription_Medicaments).HasForeignKey(e => e.IdPrescription);

                p.HasData(
                    new Prescription_Medicament { IdMedicament = 1, IdPrescription = 2, Details = "Szczegóły", Dose = 2},
                    new Prescription_Medicament { IdMedicament = 2, IdPrescription = 1, Details = "Szczegóły"}
                    );
            });
        }
    }
}
