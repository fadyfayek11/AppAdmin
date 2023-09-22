using App.Admin.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarminaAttendance.Identity;
using App.Admin.Models;
using App.Admin.ViewModels;
using Microsoft.AspNetCore.Hosting;
using DetailsDescription = App.Admin.Models.DetailsDescription;

namespace App.Admin.Controllers
{
    public class RoomDetailsController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomDetailsController(IdentityContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await _context.RoomImages.Include(r => r.Room)
                .GroupBy(x => x.RoomId)
                .Select(r => new RoomViewModel
                {
                    RoomId = r.Key,
                    RoomName = r.First().Room.NameAr,
                    Price = r.First().Room.Price,
                }).ToListAsync();

            return View(rooms);
        }
        public async Task<IActionResult> PreviewRoomDetails(int id)
        {
	        var rooms = await _context.RoomDetails.Where(r => r.RoomId == id).ToListAsync();

	        return View(rooms);
        }

		
        public IActionResult Create(int roomId)
        {
            ViewData["RoomId"] = roomId;
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomDetailsModel roomDetails)
        {
            if (ModelState.IsValid)
            {
                 var roomDetailsEntity = new RoomDetails();
                 if (roomDetails.RoomIcon is not null)
                 {
                     string imageName = Guid.NewGuid().ToString() + Path.GetExtension(roomDetails.RoomIcon.FileName);
                     string imagePath = Path.Combine("uploads", "Room", roomDetails.RoomId?.ToString()??"", imageName);
                     string filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

                     string directoryPath = Path.GetDirectoryName(filePath);
                     if (!Directory.Exists(directoryPath))
                     {
                         Directory.CreateDirectory(directoryPath);
                     }

                     using (var stream = new FileStream(filePath, FileMode.Create))
                     {
                         await roomDetails.RoomIcon.CopyToAsync(stream);
                     }

                     roomDetailsEntity = new RoomDetails
                     {
                         DetailNameEn = roomDetails.RoomDetailNameEn,
                         DetailNameAr = roomDetails.RoomDetailNameAr,
                         IsIcon = true,
                         DetailsDescription = new List<DetailsDescription>
                         {
	                         new DetailsDescription
	                         {
		                         DescriptionEn = imagePath,
		                         DescriptionAr = "",      
                                 IsIcon = true
                             }
                         },
                         RoomId = (int)roomDetails.RoomId,
                         CreatedDate = DateTime.Now
                     };
                 }
                 else
                 {
	                 var des = roomDetails.Descriptions.Select(x => new DetailsDescription
	                 {
		                 DescriptionEn = x.RoomDescriptionEn,
		                 DescriptionAr = x.RoomDescriptionAr,
                         IsIcon = false,
	                 });
					roomDetailsEntity = new RoomDetails
                     {
                         DetailNameEn = roomDetails.RoomDetailNameEn,
                         DetailNameAr = roomDetails.RoomDetailNameAr,
                         IsIcon = false,
                         DetailsDescription = des.ToList(),
                         RoomId = (int)roomDetails.RoomId,
                         CreatedDate = DateTime.Now
                     };
                 }
                 _context.RoomDetails.Add(roomDetailsEntity);
                 await _context.SaveChangesAsync();

				return RedirectToAction(nameof(PreviewRoomDetails), new { id = roomDetails.RoomId });
			}

            ViewData["RoomId"] = roomDetails.RoomId;
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
            ViewData["RoomId"] =  roomDetails.RoomId;
            return View(roomDetails);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RoomDetails roomDetails)
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
            ViewData["RoomId"] =  roomDetails.RoomId;
            return View(roomDetails);
        }

        public async Task<IActionResult> Details(int? id)
        {
	        if (id == null || _context.RoomDetails == null)
	        {
		        return NotFound();
	        }

	        var roomDetails = await _context.RoomDetails.Include(x=>x.DetailsDescription)
		        .FirstOrDefaultAsync(m => m.Id == id);
	        if (roomDetails == null)
	        {
		        return NotFound();
	        }
	        ViewData["RoomId"] = roomDetails.RoomId;

			return View(roomDetails);
        }


		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomDetails == null)
            {
                return Json(new { success = true });
            }
            var roomDetails = await _context.RoomDetails.FindAsync(id);
            if (roomDetails != null)
            {
                _context.RoomDetails.Remove(roomDetails);
            }

            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        private bool RoomDetailsExists(int id)
        {
            return (_context.RoomDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
