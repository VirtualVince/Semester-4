using labs.Areas.ProjectManagement.Models;
using labs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace labs.Areas.ProjectManagement.Controllers;

[Area("ProjectManagement")]
[Route("ProjectManagement/[controller]")]
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
            .Include(p => p.Tasks) 
            .FirstOrDefaultAsync(p => p.ProjectId == id);

        if (project == null)
        {
            return NotFound();
        }
        return View(project);
    }

    // Show the Create form
    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    // Create a project
    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Project project)
    {
        if (ModelState.IsValid)
        {
            project.StartDate = project.StartDate.ToUniversalTime(); 
            project.EndDate = project.EndDate.ToUniversalTime();     
            project.CreatedAt = DateTimeOffset.UtcNow; 

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
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
            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject == null)
            {
                return NotFound();
            }

            // ✅ Preserve DateTimeOffset format
            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.StartDate = project.StartDate.ToUniversalTime(); 
            existingProject.EndDate = project.EndDate.ToUniversalTime();
            existingProject.Status = project.Status;

            _context.Update(existingProject);
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
