namespace labs.Models
{
    public class SearchViewModel
    {
        public List<Project> Projects { get; set; } = new();
        public List<ProjectTask> Tasks { get; set; } = new();
    }
}