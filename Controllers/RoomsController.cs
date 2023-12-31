﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Admin.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Admin.Models;
using App.Admin.ViewModels;
using MarminaAttendance.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DetailsDescription = App.Admin.Models.DetailsDescription;

namespace App.Admin.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

		public RoomsController(IdentityContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}

        public async Task<IActionResult> Index()
        {
              return _context.Rooms != null ? 
                          View(await _context.Rooms.ToListAsync()) :
                          Problem("Entity set 'IdentityContext.Rooms'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomDetailsViewModel room)
        {
	        if (ModelState.Root.Children != null && ModelState.Root.Children.Count(x=>x.ValidationState == ModelValidationState.Valid ) >= 9)
            {
				string imageName = Guid.NewGuid().ToString() + Path.GetExtension(room.CoverImage.FileName);
				string imagePath = Path.Combine("uploads", "RoomCovers", Guid.NewGuid().ToString(), imageName);
				string filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

				string directoryPath = Path.GetDirectoryName(filePath);
				if (!Directory.Exists(directoryPath))
				{
					Directory.CreateDirectory(directoryPath);
				}

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await room.CoverImage.CopyToAsync(stream);
				}
	            

	            var roomEntity = new Room
	            {
		            NameAr = room.NameAr,
		            NameEn = room.NameEn,
		            DescriptionEn = room.DescriptionEn,
		            DescriptionAr = room.DescriptionAr,
                    CoverImagePath = imagePath,
		            Price = room.Price,
		            Size = room.Size,
		            MaxOccupancy = room.MaxOccupancy,
		            IsAvailable = room.IsAvailable,
		            AllowSmoking = room.AllowSmoking,
		            CreatedDate = DateTime.Now
	            };
	            await _context.Rooms.AddAsync(roomEntity);
                await _context.SaveChangesAsync();

                var roomDetailsEntity = new List<RoomDetails>();
                foreach (var roomDetail in room.RoomDetails)
                {
	                if (roomDetail.RoomIcon is not null)
	                {
						imageName = Guid.NewGuid().ToString() + Path.GetExtension(roomDetail.RoomIcon.FileName);
						imagePath = Path.Combine("uploads", "Room", roomEntity.Id.ToString(), imageName);
						imagePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

						filePath = Path.GetDirectoryName(filePath);
						if (!Directory.Exists(directoryPath))
						{
							Directory.CreateDirectory(directoryPath);
						}

						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await roomDetail.RoomIcon.CopyToAsync(stream);
						}

						
						roomDetailsEntity.Add(new RoomDetails
                        {
	                        DetailNameEn = roomDetail.RoomDetailNameEn,
	                        DetailNameAr = roomDetail.RoomDetailNameAr,
	                        IsIcon = true,
	                        RoomId = roomEntity.Id,
                            DetailsDescription = new List<DetailsDescription>()
                            {
                                new DetailsDescription
                                {
	                                DescriptionEn = imagePath,
	                                DescriptionAr = "",
                                    IsIcon = true,
                                }
                            },
	                        CreatedDate = DateTime.Now
                        });
                       
	                }
	                else
	                {
		                var des = roomDetail.Descriptions.Select(x => new DetailsDescription
		                {
			                DescriptionEn = x.RoomDescriptionEn,
			                DescriptionAr = x.RoomDescriptionAr,
                            IsIcon = false,
                        });
						roomDetailsEntity.Add(new RoomDetails
						{
							DetailNameEn = roomDetail.RoomDetailNameEn,
							DetailNameAr = roomDetail.RoomDetailNameAr,
							IsIcon = false,
							RoomId = roomEntity.Id,
                            DetailsDescription = des.ToList(),
							CreatedDate = DateTime.Now
						});
					}
	               
                }

                await _context.RoomDetails.AddRangeAsync(roomDetailsEntity);
                await _context.SaveChangesAsync();

                var roomImages = new List<RoomImages>();
                foreach (var romImage in room.RoomImages)
                {
					imageName = Guid.NewGuid().ToString() + Path.GetExtension(romImage.FileName);
					imagePath = Path.Combine("uploads", "Room", roomEntity.Id.ToString(), imageName); 
					filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);
					 
	                directoryPath = Path.GetDirectoryName(filePath);
					if (!Directory.Exists(directoryPath))
					{
						Directory.CreateDirectory(directoryPath);
					}

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await romImage.CopyToAsync(stream);
					}

                    roomImages.Add(new RoomImages
                    {
	                    Path = imagePath,
	                    RoomId = roomEntity.Id,
	                    CreatedDate = DateTime.Now
                    });
				}

                await _context.RoomImages.AddRangeAsync(roomImages);
                await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            var roomModel = new RoomModel
            {
				Id = room.Id,
				NameAr = room.NameAr,
				NameEn = room.NameEn,
				DescriptionEn = room.DescriptionEn,
				DescriptionAr = room.DescriptionAr,
				Price = room.Price,
				Size = room.Size,
				MaxOccupancy = room.MaxOccupancy,
				IsAvailable = room.IsAvailable,
				AllowSmoking = room.AllowSmoking,
			};
            return View(roomModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,RoomModel room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
	                var originalRoomCover = await _context.Rooms.Where(x=>x.Id == room.Id).Select(x=>x.CoverImagePath).FirstOrDefaultAsync();
	                var roomEntity = new Room
	                {
		                Id = room.Id,
		                NameAr = room.NameAr,
		                NameEn = room.NameEn,
		                DescriptionEn = room.DescriptionEn,
		                DescriptionAr = room.DescriptionAr,
						CoverImagePath = originalRoomCover ?? "image",
		                Price = room.Price,
		                Size = room.Size,
		                MaxOccupancy = room.MaxOccupancy,
		                IsAvailable = room.IsAvailable,
		                AllowSmoking = room.AllowSmoking,
	                };
	                if (room.CoverImagePath is not null)
	                {
		                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(room.CoverImagePath.FileName);
		                string imagePath = Path.Combine("uploads", "RoomCovers", Guid.NewGuid().ToString(), imageName);
		                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

		                string directoryPath = Path.GetDirectoryName(filePath);
		                if (!Directory.Exists(directoryPath))
		                {
			                Directory.CreateDirectory(directoryPath);
		                }

		                using (var stream = new FileStream(filePath, FileMode.Create))
		                {
			                await room.CoverImagePath.CopyToAsync(stream);
		                }

		                roomEntity.CoverImagePath = imagePath;
	                }
	               

					_context.Rooms.Update(roomEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
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
            return View(room);
        }

        

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rooms == null)
            {
	            return Json(new { success = false });
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }
            
            await _context.SaveChangesAsync();
            return Json(new { success = true });
		}

        private bool RoomExists(int id)
        {
          return (_context.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
