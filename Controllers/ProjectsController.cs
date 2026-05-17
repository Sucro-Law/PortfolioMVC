using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioMVC.Data;
using PortfolioMVC.Models;

namespace PortfolioMVC.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Projects
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .OrderByDescending(p => p.IsFeatured)
                .ThenByDescending(p => p.CreatedAt)
                .ToListAsync();
            return View(projects);
        }

        // GET: /Projects/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return NotFound();
            return View(project);
        }

        // GET: /Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,TechStack,GitHubUrl,LiveUrl,ImageUrl,IsFeatured")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.CreatedAt = DateTime.UtcNow;
                _context.Add(project);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Project added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: /Projects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return NotFound();
            return View(project);
        }

        // POST: /Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TechStack,GitHubUrl,LiveUrl,ImageUrl,IsFeatured,CreatedAt")] Project project)
        {
            if (id != project.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Project updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Projects.Any(e => e.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: /Projects/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return NotFound();
            return View(project);
        }

        // POST: /Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Project deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
