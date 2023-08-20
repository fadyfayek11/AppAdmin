﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Admin.Models;
using App.Admin.ViewModels;
using MarminaAttendance.Identity;
using Microsoft.AspNetCore.Hosting;

namespace App.Admin.Controllers
{
    public class CMSController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public CMSController(IdentityContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Cmses != null ? 
                          View(await _context.Cmses.Where(x=>x.Key == "OurTeam").ToListAsync()) :
                          Problem("Entity set 'IdentityContext.Cmses'  is null.");
        }

        // GET: CMS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cmses == null)
            {
                return NotFound();
            }

            var cMS = await _context.Cmses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cMS == null)
            {
                return NotFound();
            }

            return View(cMS);
        }

        // GET: CMS/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImagesModel images)
        {
            if (ModelState.IsValid)
            {
                var newImages = new List<CMS>();

                foreach (var image in images.Images)
                {
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    string imagePath = Path.Combine("uploads", "OurTeam", imageName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

                    string directoryPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    newImages.Add(new CMS
                    {
                        Key = images.Key,
                        Value = imagePath
                    });
                }

               
                _context.Cmses.AddRange(newImages);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(images);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cmses == null)
            {
                return NotFound();
            }

            var cMS = await _context.Cmses.FindAsync(id);
            if (cMS == null)
            {
                return NotFound();
            }
            return View(cMS);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Key,Value")] CMS cMS)
        {
            if (id != cMS.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cMS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CMSExists(cMS.Id))
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
            return View(cMS);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cmses == null)
            {
                return NotFound();
            }

            var cMS = await _context.Cmses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cMS == null)
            {
                return NotFound();
            }

            return View(cMS);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cmses == null)
            {
                return Problem("Entity set 'IdentityContext.Cmses'  is null.");
            }
            var cMS = await _context.Cmses.FindAsync(id);
            if (cMS != null)
            {
                _context.Cmses.Remove(cMS);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CMSExists(int id)
        {
          return (_context.Cmses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
