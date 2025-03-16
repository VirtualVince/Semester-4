using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace labs.Areas.ProjectManagement.Models
{
    public class ProjectTask
    {
        [Key]
        public int ProjectTaskId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public int ProjectId { get; set; } // Foreign Key

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } // Navigation Property
    }
}