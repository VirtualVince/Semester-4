using System.ComponentModel.DataAnnotations;

namespace labs.Areas.ProjectManagement.Models;

public class Project
{
    public int ProjectId { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    
    public List<ProjectTask> Tasks { get; set; } = new();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

}
