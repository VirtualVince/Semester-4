using labs.Areas.ProjectManagement.Models;
using labs.Data;
using labs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace labs.Areas.ProjectManagement.Controllers;

[Area("ProjectManagement")]
[Route("ProjectManagement/projects/{projectId:int}/tasks")]
public class ProjectTaskController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectTaskController(ApplicationDbContext context)
    {
        _context = context;
    }

    // List tasks for a project
    [HttpGet("")]
    public async Task<IActionResult> Index(int projectId)
    {
        var project = await _context.Projects
            .Include(p => p.Tasks) 
            .FirstOrDefaultAsync(p => p.ProjectId == projectId);

        if (project == null)
        {
            return NotFound();
        }

        return View(project); 
    }

    // Task details
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var task = await _context.ProjectTasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        return View(task);
    }

    // Create a task
    [HttpGet("create")]
    public IActionResult Create(int projectId)
    {
        var task = new ProjectTask { ProjectId = projectId };
        return View(task);
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProjectTask task)
    {
        if (!ModelState.IsValid) 
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(task);
        }

       
        var projectExists = await _context.Projects.AnyAsync(p => p.ProjectId == task.ProjectId);
        if (!projectExists)
        {
            ModelState.AddModelError("", "Invalid Project ID");
            return View(task);
        }

        _context.ProjectTasks.Add(task);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", new { projectId = task.ProjectId });
    }

    // Edit a task
    [HttpGet("edit/{id:int}")]
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _context.ProjectTasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpPost("edit/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProjectTask task)
    {
        if (id != task.ProjectTaskId)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { projectId = task.ProjectId });
        }
        return View(task);
    }

    // DELETE a task
    [HttpGet("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context.ProjectTasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpPost("delete/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var task = await _context.ProjectTasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.ProjectTasks.Remove(task);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", new { projectId = task.ProjectId });
    }
}
