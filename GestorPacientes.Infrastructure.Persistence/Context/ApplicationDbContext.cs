using GestorPacientes.Core.Domain.Common;
using GestorPacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        
        }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<LaboratoryTest> LaboratoryTests { get; set;}
        public DbSet<LaboratoryTestResult> LaboratoryTestResults { get; set;}
        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch(entry.State)
                { 
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                    break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                    break;
                
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region "Tables"
            modelBuilder.Entity<Rol>().ToTable("Rols");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<LaboratoryTest>().ToTable("LaboratoryTests");
            modelBuilder.Entity<LaboratoryTestResult>().ToTable("LaboratoryTestResults");
            modelBuilder.Entity<MedicalAppointment>().ToTable("MedicalAppointments");
            #endregion

            #region "PrimaryKey"
            modelBuilder.Entity<Rol>().HasKey(r => r.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<LaboratoryTest>().HasKey(lb => lb.Id);
            modelBuilder.Entity<LaboratoryTestResult>().HasKey(lbr => lbr.Id);
            modelBuilder.Entity<MedicalAppointment>().HasKey(ma => ma.Id);
            #endregion

            #region "Relantioship"

            modelBuilder.Entity<Rol>()
                .HasMany<User>(u => u.Users)
                .WithOne(r => r.Rol)
                .HasForeignKey(r => r.IdRol)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany<MedicalAppointment>(m => m.Appointments)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>()
                .HasMany<MedicalAppointment>(m => m.Appointments)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LaboratoryTestResult>()
                .HasOne<LaboratoryTest>(lbr => lbr.Laboratory)
                .WithMany(lb => lb.Tests)
                .HasForeignKey(lbr => lbr.IdLaboratoryTest)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LaboratoryTestResult>()
              .HasOne<MedicalAppointment>(lb => lb.MedicalAppointment)
              .WithMany(p => p.Tests)
              .HasForeignKey(lb => lb.IdMedicalAppointment);

            modelBuilder.Entity<LaboratoryTestResult>()
              .HasOne<Patient>(lb => lb.Patient)
              .WithMany(p => p.Tests)
              .HasForeignKey(lb => lb.IdPatient);

            #endregion

            #region "Data"
            modelBuilder.Entity<Rol>()
                .HasData(
                new Rol { Id = 1, Name = "Administrator" },
                new Rol { Id = 2, Name = "Assistant" });
            #endregion

            #region "User"

            modelBuilder.Entity<User>()
              .Property(u => u.Name)
              .IsRequired()
              .HasMaxLength(100);

            modelBuilder.Entity<User>()
              .Property(u => u.LastName)
              .IsRequired()
              .HasMaxLength(100);

            modelBuilder.Entity<User>()
              .Property(u => u.UserName)
              .IsRequired()
              .HasMaxLength(150);

            modelBuilder.Entity<User>()
              .Property(u => u.Password)
              .IsRequired();

            modelBuilder.Entity<User>()
              .Property(u => u.Email)
              .IsRequired();


            #endregion

            #region "Patient"
            modelBuilder.Entity<Patient>()
              .Property(p => p.Name)
              .IsRequired()
              .HasMaxLength(100);

            modelBuilder.Entity<Patient>()
              .Property(p => p.LastName)
              .IsRequired()
              .HasMaxLength(100);

            modelBuilder.Entity<Patient>()
              .Property(p => p.Direction)
              .IsRequired();

            modelBuilder.Entity<Patient>()
              .Property(p => p.Phone)
              .IsRequired();

            modelBuilder.Entity<Patient>()
              .Property(p => p.Identification)
              .IsRequired();
            #endregion

            #region "Doctor"
            modelBuilder.Entity<Doctor>()
              .Property(d => d.Name)
              .IsRequired()
              .HasMaxLength(100);

            modelBuilder.Entity<Doctor>()
              .Property(d => d.LastName)
              .IsRequired()
              .HasMaxLength(100);

            modelBuilder.Entity<Doctor>()
              .Property(d => d.Email)
              .IsRequired();

            modelBuilder.Entity<Doctor>()
              .Property(d => d.Identification)
              .IsRequired();
            #endregion

            #region "LaboratoryTest"

            modelBuilder.Entity<LaboratoryTest>()
              .Property(lb => lb.Name)
              .IsRequired()
              .HasMaxLength(150);

            #endregion

            #region "Medical Appointment"

            modelBuilder.Entity<MedicalAppointment>()
              .Property(ma => ma.Date)
              .IsRequired();
            modelBuilder.Entity<MedicalAppointment>()
              .Property(ma => ma.Hour)
              .IsRequired();
            modelBuilder.Entity<MedicalAppointment>()
              .Property(ma => ma.Cause)
              .IsRequired();

            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
