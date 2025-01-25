using labs.Models;
using Microsoft.AspNetCore.Mvc;

namespace labs.Controllers;

public class ProjectsController : Controller
{
    /// <summary>
    /// Index action will retrieve a listing of projects (database)
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Index()
    {
        var projects = new List<Project>
        {
            new Project { ProjectId = 1, Name = "Project 1", Description = "First project description" },
            // Database call will go here I assume
        };
        return View(projects);
    }
}