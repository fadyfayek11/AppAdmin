using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarminaAttendance.Identity;
using App.Admin.Models;

namespace App.Admin.Controllers
{
    public class RoomDetailsController : Controller
    {
        private readonly IdentityContext _context;

        public RoomDetailsController(IdentityContext context)
        {
            _context = context;
        }

        // GET: RoomDetails
        public async Task<IActionResult> Index()
        {
            var identityContext = _context.RoomDetails.Include(r => r.Room);
            return View(await identityContext.ToListAsync());
        }

        // GET: RoomDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomDetails == null)
            {
                return NotFound();
            }

            var roomDetails = await _context.RoomDetails
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomDetails == null)
            {
                return NotFound();
            }

            return View(roomDetails);
        }

        // GET: RoomDetails/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id");
            return View();
        }

        // POST: RoomDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DetailNameEn,DetailNameAr,DescriptionEn,DescriptionAr,IsIcon,RoomId,CreatedDate")] RoomDetails roomDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", roomDetails.RoomId);
            return View(roomDetails);
        }

        // GET: RoomDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomDetails == null)
            {
                return NotFound();
            }

            var roomDetails = await _context.RoomDetails.FindAsync(id);
            if (roomDetails == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", roomDetails.RoomId);
            return View(roomDetails);
        }

        // POST: RoomDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DetailNameEn,DetailNameAr,DescriptionEn,DescriptionAr,IsIcon,RoomId,CreatedDate")] RoomDetails roomDetails)
        {
            if (id != roomDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomDetailsExists(roomDetails.Id))
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
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", roomDetails.RoomId);
            return View(roomDetails);
        }

        // GET: RoomDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomDetails == null)
            {
                return NotFound();
            }

            var roomDetails = await _context.RoomDetails
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomDetails == null)
            {
                return NotFound();
            }

            return View(roomDetails);
        }

        // POST: RoomDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomDetails == null)
            {
                return Problem("Entity set 'IdentityContext.RoomDetails'  is null.");
            }
            var roomDetails = await _context.RoomDetails.FindAsync(id);
            if (roomDetails != null)
            {
                _context.RoomDetails.Remove(roomDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomDetailsExists(int id)
        {
            return (_context.RoomDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
