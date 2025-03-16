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
    }
}