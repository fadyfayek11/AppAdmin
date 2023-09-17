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
		public async Task<IActionResult> About()
		{
			var coverTextAr = await _context.Cmses.Where(x => x.Key == "CoverTextAr").Select(x=>x.Value).ToListAsync();
			var coverTextEn = await _context.Cmses.Where(x => x.Key == "CoverTextEn").Select(x=>x.Value).ToListAsync();
			var coverImages = await _context.Cmses.Where(x => x.Key == "CoverImage").Select(x => x.Value).ToListAsync();
			var aboutImages = await _context.Cmses.Where(x => x.Key == "AboutImages").Select(x => x.Value).ToListAsync();
			var aboutTitleEn = await _context.Cmses.Where(x => x.Key == "AboutTitleEn").Select(x=>x.Value).FirstOrDefaultAsync();
			var aboutTitleAr = await _context.Cmses.Where(x => x.Key == "AboutTitleAr").Select(x => x.Value).FirstOrDefaultAsync();
			var aboutAr = await _context.Cmses.Where(x => x.Key == "AboutAr").Select(x => x.Value).FirstOrDefaultAsync();
			var aboutEn = await _context.Cmses.Where(x => x.Key == "AboutEn").Select(x => x.Value).FirstOrDefaultAsync();

			var model = new AboutModel
			{
				AboutImages = aboutImages,
				AboutTitleEn = aboutTitleEn ?? "",
				AboutTitleAr = aboutTitleAr ?? "",
				AboutAr = aboutAr ?? "",
				AboutEn = aboutEn ?? ""
			};
			return View(model);
		}
		
		public async Task<IActionResult> CoverText()
		{
			var coverTextAr = await _context.Cmses.Where(x => x.Key == "CoverTextAr").Select(x=>x.Value).FirstOrDefaultAsync();
			var coverTextEn = await _context.Cmses.Where(x => x.Key == "CoverTextEn").Select(x=>x.Value).FirstOrDefaultAsync();
			var coverImages = await _context.Cmses.Where(x => x.Key == "CoverImage").Select(x => x.Value).FirstOrDefaultAsync();

			var model = new CoverText
			{
				CoverTextAr = coverTextAr,
				CoverTextEn = coverTextEn,
				CoverImage = coverImages
			};
			return View(model);
		}

		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ImagesModel images)
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

        [HttpPost, ActionName("Delete")]
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
