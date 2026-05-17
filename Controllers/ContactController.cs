using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioMVC.Data;
using PortfolioMVC.Models;

namespace PortfolioMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Contact
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Name,Email,Subject,Message")] ContactMessage contactForm)
        {
            if (ModelState.IsValid)
            {
                contactForm.SentAt = DateTime.UtcNow;
                _context.ContactMessages.Add(contactForm);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Message sent successfully! I'll get back to you soon.";
                return RedirectToAction(nameof(Index));
            }
            return View(contactForm);
        }

        // GET: /Contact/Messages (inbox)
        public async Task<IActionResult> Messages()
        {
            var messages = await _context.ContactMessages
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();
            return View(messages);
        }

        // POST: /Contact/MarkRead/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkRead(int id)
        {
            var message = await _context.ContactMessages.FindAsync(id);
            if (message == null) return NotFound();

            message.IsRead = true;
            await _context.SaveChangesAsync();
            TempData["Success"] = "Message marked as read.";
            return RedirectToAction(nameof(Messages));
        }

        // POST: /Contact/MarkUnread/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkUnread(int id)
        {
            var message = await _context.ContactMessages.FindAsync(id);
            if (message == null) return NotFound();

            message.IsRead = false;
            await _context.SaveChangesAsync();
            TempData["Success"] = "Message marked as unread.";
            return RedirectToAction(nameof(Messages));
        }

        // POST: /Contact/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _context.ContactMessages.FindAsync(id);
            if (message != null)
            {
                _context.ContactMessages.Remove(message);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Message deleted.";
            }
            return RedirectToAction(nameof(Messages));
        }
    }
}
