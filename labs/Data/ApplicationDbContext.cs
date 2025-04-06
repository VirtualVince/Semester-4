using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using labs.Areas.ProjectManagement.Models;
using labs.Models;

namespace labs.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Important for Identity

            modelBuilder.Entity<Project>()
                .Property(p => p.StartDate)
                .HasColumnType("timestamptz");

            modelBuilder.Entity<Project>()
                .Property(p => p.EndDate)
                .HasColumnType("timestamptz");

            modelBuilder.Entity<Project>()
                .Property(p => p.CreatedAt)
                .HasColumnType("timestamptz");
        }
    }
}