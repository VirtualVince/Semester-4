using System.ComponentModel.DataAnnotations;

namespace labs.Areas.ProjectManagement.Models;

public class Project
{
    public int ProjectId { get; set; }

    [Display(Name = "Project Name")]
    [StringLength(100, ErrorMessage = "Name too long!")]
    public string Name { get; set; }

    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; }

    public List<ProjectTask> Tasks { get; set; } = new();

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
}