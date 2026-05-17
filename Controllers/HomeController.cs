using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioMVC.Data;

namespace PortfolioMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var featuredProjects = await _context.Projects
                .Where(p => p.IsFeatured)
                .OrderByDescending(p => p.CreatedAt)
                .Take(3)
                .ToListAsync();

            var skills = await _context.Skills
                .OrderBy(s => s.Category)
                .ToListAsync();

            ViewBag.FeaturedProjects = featuredProjects;
            ViewBag.Skills = skills;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
