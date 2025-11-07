using Microsoft.EntityFrameworkCore;
using HeathEdWeb.Models;

namespace HeathEdWeb.Data
{
    public class HeathEdDbContext : DbContext
    {
        public HeathEdDbContext(DbContextOptions<HeathEdDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<StudentModule> StudentModules { get; set; }
        public DbSet<CaseStudy> CaseStudies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Role);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            // Configure Module entity
            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasIndex(e => e.ModuleCode).IsUnique();
                entity.HasIndex(e => e.LecturerID);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasOne(m => m.Lecturer)
                    .WithMany(u => u.ModulesAsLecturer)
                    .HasForeignKey(m => m.LecturerID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure StudentModule entity
            modelBuilder.Entity<StudentModule>(entity =>
            {
                entity.HasIndex(e => new { e.StudentID, e.ModuleID }).IsUnique();
                entity.HasIndex(e => e.StudentID);
                entity.HasIndex(e => e.ModuleID);
                entity.Property(e => e.EnrolledDate).HasDefaultValueSql("GETDATE()");

                entity.HasOne(sm => sm.Student)
                    .WithMany(u => u.StudentModules)
                    .HasForeignKey(sm => sm.StudentID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sm => sm.Module)
                    .WithMany(m => m.StudentModules)
                    .HasForeignKey(sm => sm.ModuleID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure CaseStudy entity
            modelBuilder.Entity<CaseStudy>(entity =>
            {
                entity.HasIndex(e => e.ModuleID);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasOne(c => c.Module)
                    .WithMany(m => m.CaseStudies)
                    .HasForeignKey(c => c.ModuleID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
