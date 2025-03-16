using Microsoft.AspNetCore.Mvc;
using labs.Data;
using System.Linq;
using System.Threading.Tasks;

public class ProjectSummaryViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;

    public ProjectSummaryViewComponent(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var projectCount = _context.Projects.Count();
        return View(projectCount);
    }
}