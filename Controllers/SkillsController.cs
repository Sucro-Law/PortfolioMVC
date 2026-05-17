using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioMVC.Data;
using PortfolioMVC.Models;

namespace PortfolioMVC.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Skills
        public async Task<IActionResult> Index()
        {
            var skills = await _context.Skills
                .OrderBy(s => s.Category)
                .ThenBy(s => s.Name)
                .ToListAsync();
            return View(skills);
        }

        // GET: /Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Skills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Category,Proficiency")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skill);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Skill \"{skill.Name}\" added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: /Skills/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return NotFound();
            return View(skill);
        }

        // POST: /Skills/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,Proficiency")] Skill skill)
        {
            if (id != skill.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skill);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = $"Skill \"{skill.Name}\" updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Skills.Any(e => e.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: /Skills/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return NotFound();
            return View(skill);
        }

        // POST: /Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Skill \"{skill.Name}\" deleted.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
