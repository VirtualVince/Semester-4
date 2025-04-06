using System.ComponentModel.DataAnnotations;

namespace labs.Areas.ProjectManagement.Models;

public class ProjectComment
{
   public  int ProjectCommentId { get; set; }
   
   [Display(Name="Project Message")]
   [StringLength((500, ErrorMessage = "Project name cannot be longer than 500 characters."))]
   public string? Content { get; set; }
   
   [Display(Name="Date Created")]
   [DataType(DataType.DateTime)]
   private DateTime _dateCreated;
   public DateTime DateCreated 
   { 
       get => _dateCreated;
       set => _dateCreated = DateTime.SpecifyKind(value, DateTimeKind.Utc);
   }
   //Foreign
   public int ProjectId {get; set;}
   
   //Navaigation Property
   public Project? Project { get; set; }
}