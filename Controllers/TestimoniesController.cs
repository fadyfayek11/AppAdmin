using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Admin.Models;
using MarminaAttendance.Identity;

namespace App.Admin.Controllers
{
    public class TestimoniesController : Controller
    {
        private readonly IdentityContext _context;

        public TestimoniesController(IdentityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Testimonies != null ? 
                          View(await _context.Testimonies.ToListAsync()) :
                          Problem("Entity set 'IdentityContext.Testimonies'  is null.");
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimony testimony)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testimony);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testimony);
        }

        // GET: Testimonies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Testimonies == null)
            {
                return NotFound();
            }

            var testimony = await _context.Testimonies.FindAsync(id);
            if (testimony == null)
            {
                return NotFound();
            }
            return View(testimony);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Testimony testimony)
        {
            if (id != testimony.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testimony);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonyExists(testimony.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testimony);
        }

      

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Testimonies == null)
            {
				return Json(new { success = false });
            }
			var testimony = await _context.Testimonies.FindAsync(id);
            if (testimony != null)
            {
                _context.Testimonies.Remove(testimony);
            }
            
            await _context.SaveChangesAsync();
			return Json(new { success = true });
        }

		private bool TestimonyExists(int id)
        {
          return (_context.Testimonies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
