using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Admin.Models;
using MarminaAttendance.Identity;

namespace App.Admin.Controllers
{
    public class RoomImagesController : Controller
    {
        private readonly IdentityContext _context;

        public RoomImagesController(IdentityContext context)
        {
            _context = context;
        }

        // GET: RoomImages
        public async Task<IActionResult> Index()
        {
            var identityContext = _context.RoomImages.Include(r => r.Room);
            return View(await identityContext.ToListAsync());
        }

        // GET: RoomImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomImages == null)
            {
                return NotFound();
            }

            var roomImages = await _context.RoomImages
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomImages == null)
            {
                return NotFound();
            }

            return View(roomImages);
        }

        // GET: RoomImages/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id");
            return View();
        }

        // POST: RoomImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Path,RoomId,CreatedDate")] RoomImages roomImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomImages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", roomImages.RoomId);
            return View(roomImages);
        }

        // GET: RoomImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomImages == null)
            {
                return NotFound();
            }

            var roomImages = await _context.RoomImages.FindAsync(id);
            if (roomImages == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", roomImages.RoomId);
            return View(roomImages);
        }

        // POST: RoomImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Path,RoomId,CreatedDate")] RoomImages roomImages)
        {
            if (id != roomImages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomImagesExists(roomImages.Id))
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
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", roomImages.RoomId);
            return View(roomImages);
        }

        // GET: RoomImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomImages == null)
            {
                return NotFound();
            }

            var roomImages = await _context.RoomImages
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomImages == null)
            {
                return NotFound();
            }

            return View(roomImages);
        }

        // POST: RoomImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomImages == null)
            {
                return Problem("Entity set 'IdentityContext.RoomImages'  is null.");
            }
            var roomImages = await _context.RoomImages.FindAsync(id);
            if (roomImages != null)
            {
                _context.RoomImages.Remove(roomImages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomImagesExists(int id)
        {
          return (_context.RoomImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
