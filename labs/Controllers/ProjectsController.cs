using labs.Data;
using labs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace labs.Controllers;

[Route("projects")]
public class ProjectsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // List all projects
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var projects = await _context.Projects.ToListAsync();
        return View(projects);
    }

    // View project details (include tasks)
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        var project = await _context.Projects
            .Include(p => p.Tasks) // Include related tasks
            .FirstOrDefaultAsync(p => p.ProjectId == id);

        if (project == null)
        {
            return NotFound();
        }
        return View(project);
    }

    // Edit a project
    [HttpGet("edit/{id:int}")]
    public async Task<IActionResult> Edit(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return View(project);
    }

    [HttpPost("edit/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Project project)
    {
        if (id != project.ProjectId)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _context.Update(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(project);
    }

    // DELETE a project
    [HttpGet("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return View(project);
    }

    [HttpPost("delete/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
