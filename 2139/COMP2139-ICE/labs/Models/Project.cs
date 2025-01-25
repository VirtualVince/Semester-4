using System.ComponentModel.DataAnnotations;

namespace labs.Models;

public class Project
{
    /// <summary>
    /// The unique identifier for the project entity
    /// </summary>
    public int ProjectId { get; set; }
    
    /// <summary>
    /// Required field describing a projects name
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public string Status { get; set; }
    
    
}