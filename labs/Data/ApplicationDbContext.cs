using labs.Areas.ProjectManagement.Models;
using Microsoft.EntityFrameworkCore;
using labs.Models; // Ensure correct namespace for Project model

namespace labs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Project> Projects { get; set; } // DbSet for Project entity
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(p => p.StartDate)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<Project>()
                .Property(p => p.EndDate)
                .HasColumnType("timestamp without time zone");
        }
    }
}