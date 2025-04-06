using labs.Areas.ProjectManagement.Models;
using labs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace labs.Areas.ProjectManagement.Controllers
{
    [Area("ProjectManagement")]
    [Route("ProjectManagement/Projects/{projectId:int}/Comments")]
    public class ProjectCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fetch all comments for a project (for AJAX)
        [HttpGet("")]
        public async Task<IActionResult> GetComments(int projectId)
        {
            var comments = await _context.ProjectComments
                .Where(c => c.ProjectId == projectId)
                .OrderByDescending(c => c.DateCreated)
                .ToListAsync();
            return Json(comments);
        }

        // POST: Add a new comment (for AJAX)
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int projectId, [FromForm] string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return BadRequest("Comment cannot be empty.");
            }

            var comment = new ProjectComment
            {
                ProjectId = projectId,
                Content = content,
                DateCreated = DateTime.UtcNow
            };

            _context.ProjectComments.Add(comment);
            await _context.SaveChangesAsync();

            // Return the newly added comment as JSON
            return Json(comment);
        }
    }
}