using System;
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
    public class NewsController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsController(IdentityContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
              return _context.News != null ? 
                          View(await _context.News.ToListAsync()) :
                          Problem("Entity set 'IdentityContext.News'  is null.");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsModel news)
        {
            if (ModelState.IsValid)
            {
                var image = "";
                if (news.CoverImagePath != null)
                {
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(news.CoverImagePath.FileName);
                    string imagePath = Path.Combine("uploads", "newsImages", imageName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

                    string directoryPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directoryPath))
                    {
	                    Directory.CreateDirectory(directoryPath);
                    }

					using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await news.CoverImagePath.CopyToAsync(stream);
                    }

                    image = imagePath;
                }

                var newsEntity = new News
                {
                    Title = news.Title,
                    CoverImagePath = image,
                    ContentEn = news.ContentEn,
                    ContentAr = news.ContentAr,
                    DatePublished = DateTime.Now
                };

                _context.Add(newsEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(news);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(new NewsModel
            {
	            Id = news.Id,
	            Title = news.Title,
	            Path = news.CoverImagePath,
	            ContentEn = news.ContentEn,
	            ContentAr = news.ContentAr
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewsModel news)
        {
			if (id != news.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var existingNews = await _context.News.FindAsync(id);

					if (news.CoverImagePath != null)
					{
						string imageName = Guid.NewGuid().ToString() + Path.GetExtension(news.CoverImagePath.FileName);
						string imagePath = Path.Combine("uploads", "newsImages", imageName);
						string filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

						string directoryPath = Path.GetDirectoryName(filePath);
						if (!Directory.Exists(directoryPath))
						{
							Directory.CreateDirectory(directoryPath);
						}
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await news.CoverImagePath.CopyToAsync(stream);
						}

						existingNews.CoverImagePath = imagePath;
					}

					existingNews.Title = news.Title;
					existingNews.ContentEn = news.ContentEn;
					existingNews.ContentAr = news.ContentAr;

					_context.Update(existingNews);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!NewsExists(id))
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
			return View(news);
		}


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.News == null)
            {
				return Json(new { success = false });
            }
			var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }
            
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

		private bool NewsExists(int id)
        {
          return (_context.News?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
