using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using labs.Areas.ProjectManagement.Models;
using labs.Models;

namespace labs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(p => p.StartDate)
                .HasColumnType("timestamptz");  // Use "timestamptz" for PostgreSQL (with timezone)

            modelBuilder.Entity<Project>()
                .Property(p => p.EndDate)
                .HasColumnType("timestamptz");  

            modelBuilder.Entity<Project>()
                .Property(p => p.CreatedAt)
                .HasColumnType("timestamptz");  
        }

        }
    }
