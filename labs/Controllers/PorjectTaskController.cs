using labs.Data;
using labs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace labs.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectTaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all tasks for a project
        [HttpGet]
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

        // Show details of a specific task
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await _context.ProjectTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // Show the Create form
        [HttpGet]
        public IActionResult Create(int projectId)
        {
            var task = new ProjectTask { ProjectId = projectId };
            return View(task);
        }

        // Handle task creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                _context.ProjectTasks.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { projectId = task.ProjectId });
            }
            return View(task);
        }

        // Show the Edit form
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.ProjectTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // Handle task updates
        [HttpPost]
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

        // Show the Delete confirmation page
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.ProjectTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // Handle task deletion
        [HttpPost, ActionName("Delete")]
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
}
