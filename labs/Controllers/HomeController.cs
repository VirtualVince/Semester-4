using System.Diagnostics;
using labs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using labs.Models;
namespace labs.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpGet]
    public async Task<IActionResult> Search(string searchTerm)
    {
        var projects = await _context.Projects
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .ToListAsync();

        var tasks = await _context.ProjectTasks
            .Where(t => t.Title.Contains(searchTerm) || t.Description.Contains(searchTerm))
            .ToListAsync();

        var results = new SearchViewModel
        {
            Projects = projects,
            Tasks = tasks
        };

        return View(results);
    }
    public IActionResult NotFoundPage()
    {
        return View("NotFound");
    }
}
