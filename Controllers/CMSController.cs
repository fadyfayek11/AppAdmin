using App.Admin.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Admin.Models;
using App.Admin.ViewModels;
using System;

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
		
            var about = await _context.Cmses.FirstOrDefaultAsync(x => x.Key == "About");

            if (about == null)
            {
	            return View(new AboutModel());
            }
            var model = new AboutModel
			{
                Id = about.Id,
                AboutImages = new List<string>
                {
                    about.Value.Split("#")[4],
                    about.Value.Split("#")[5],
                    about.Value.Split("#")[6],
                }, 
                HeaderAr = about.Value.Split("#")[0],
                HeaderEn = about.Value.Split("#")[1],
                AboutAr = about.Value.Split("#")[2],
				AboutEn = about.Value.Split("#")[3]
            };
			return View(model);
		}
        public async Task<IActionResult> EditAbout(int id)
        {
            var about = await _context.Cmses.FirstOrDefaultAsync(x => x.Id == id);

            if (about == null)
            {
                return View(new EditAbout());
            }
            try
            {
                var model = new EditAbout
                {
                    Id = about.Id,
                    HeaderAr = about.Value.Split("#")[0],
                    HeaderEn = about.Value.Split("#")[1],
                    AboutAr = about.Value.Split("#")[2],
                    AboutEn = about.Value.Split("#")[3]
                };
                return View(model);
            }
            catch (Exception)
            {

                return View();
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAbout([FromForm] EditAbout about)
        {
            if (ModelState.IsValid)
            {
                var image1 = await UploadImages(about.Image1);
                var image2 = await UploadImages(about.Image2);
                var image3 = await UploadImages(about.Image3);

                var newCover = new CMS
                {
                    Id = about.Id,
                    Key = "About",
                    Value = about.HeaderAr + "#" + about.HeaderEn + "#" + about.AboutAr + "#" + about.AboutEn + "#" + image1 + "#" + image2 + "#" + image3,
                };
           
                _context.Cmses.Update(newCover);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(About));
            }

            return View(about);
        }

        private async Task<string> UploadImages(IFormFile image)
        {
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            string imagePath = Path.Combine("uploads", "About", imageName);
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
            return imagePath;
        }
        public async Task<IActionResult> CoverText()
		{			
			var coverImages = await _context.Cmses.Where(x => x.Key == "CoverText").ToListAsync();
            
            var model = coverImages.Select(x => new CoverTexts
            {
                Id = x.Id,
                HeaderAr = x.Value.Split("#")[0],
                HeaderEn = x.Value.Split("#")[1],
                CoverTextAr = x.Value.Split("#")[2],
                CoverTextEn = x.Value.Split("#")[3],
                CoverImage = x.Value.Split("#")[4]
            });
			return View(model);
		}
        public IActionResult AddCoverText()
        {
            return View();
        }
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddCoverText([FromForm] CoverText covers)
		{
			if (ModelState.IsValid)
			{
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(covers.CoverImage.FileName);
				string imagePath = Path.Combine("uploads", "Covers", imageName);
				string filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

				string directoryPath = Path.GetDirectoryName(filePath);
				if (!Directory.Exists(directoryPath))
				{
					Directory.CreateDirectory(directoryPath);
				}

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await covers.CoverImage.CopyToAsync(stream);
				}

				var newCover = new CMS
				{
                    Key = "CoverText",
                    Value = covers.HeaderAr + "#" + covers.HeaderEn + "#" + covers.CoverTextAr + "#" + covers.CoverTextEn + "#" + imagePath,
				};
				await _context.Cmses.AddAsync(newCover);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(CoverText));
			}

			return View(covers);
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
                return Problem("Entity set 'IdentityContext.Cms' is null.");
            }
            var cMS = await _context.Cmses.FindAsync(id);
            if (cMS != null)
            {
                _context.Cmses.Remove(cMS);
            }
            
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        private bool CMSExists(int id)
        {
          return (_context.Cmses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
