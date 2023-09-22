using App.Admin.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Admin.Models;
using App.Admin.ViewModels;
using MarminaAttendance.Identity;

namespace App.Admin.Controllers
{
    public class RoomImagesController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public RoomImagesController(IdentityContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await _context.RoomImages.Include(r => r.Room)
                .GroupBy(x=>x.RoomId)
                .Select(r=>new RoomViewModel
            {
	            RoomId = r.Key,
	            RoomName = r.First().Room.NameAr,
	            Price = r.First().Room.Price,
            }).ToListAsync();

            return View(rooms);
        }
        public async Task<IActionResult> PreviewRoomImages(int id)
        {
	        var rooms = await _context.RoomImages.Where(r => r.RoomId == id).ToListAsync();

            return View(rooms);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ImagesModel images)
        {
            if (ModelState.IsValid)
            {
                var newImages = new List<RoomImages>();

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

                    newImages.Add(new RoomImages()
                    {
                        RoomId = (int)images.Id,
                        Path = imagePath
                    });
                }


                _context.RoomImages.AddRange(newImages);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(PreviewRoomImages), new{id = images.Id});
            }

            return View(images);
        }

        public IActionResult Create(int roomId)
        {
            ViewData["RoomId"] = roomId;
            return View();
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomImages == null)
            {
                return Json(new { success = false });
            }
            var roomImages = await _context.RoomImages.FindAsync(id);
            if (roomImages != null)
            {
                _context.RoomImages.Remove(roomImages);
            }
            
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        private bool RoomImagesExists(int id)
        {
          return (_context.RoomImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
