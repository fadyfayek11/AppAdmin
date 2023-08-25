using App.Admin.Models;
using App.Admin.ViewModels;
using MarminaAttendance.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    public class HomeController : Controller
	{
		private readonly IdentityContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public HomeController(IWebHostEnvironment webHostEnvironment, IdentityContext context)
		{
			_webHostEnvironment = webHostEnvironment;
			_context = context;
		}
        public async Task<IActionResult> Index(string lang = "en")
        {
			var rooms = await _context.Rooms
				.Include(x=>x.RoomDetails)!
				.ThenInclude(x=>x.DetailsDescription)
				.Include(x=>x.RoomImages)
				.Take(6)
				.Select(x=>new RoomsHomeViewModel
				{
					Name = lang == "ar" ? x.NameAr : x.NameEn,
					Description = lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
					Price = x.Price,
					Size = x.Size,
					MaxOccupancy = x.MaxOccupancy,
					AllowSmoking = x.AllowSmoking,
					RoomDetails = x.RoomDetails!.Select(y=> new RoomDetailsHomeViewModel
					{
						DetailName = lang == "ar" ? y.DetailNameAr : y.DetailNameEn,
						IsIcon = y.IsIcon,
						RoomId = y.RoomId,
						DetailsDescription = y.DetailsDescription.Select(z=>new DetailsDescriptionHomeViewModel
						{
							Description = lang == "ar" ? z.DescriptionAr : z.DescriptionEn,
							IsIcon = z.IsIcon,
							RoomDetailsId = z.RoomDetailsId
						}).ToList()
					}).ToList(),
					RoomImages = x.RoomImages!.Select(c=>new RoomImagesHomeViewModel
					{
						Path = c.Path,
						RoomId = c.RoomId,
					}).ToList()
				}).ToListAsync();
			var team = await _context.Cmses.Where(x => x.Key == "OurTeam").Select(x => new TeamHomeViewModel
			{
				Key = x.Key,
				Value = x.Value,
			}).ToListAsync();
			var testimonies = await _context.Testimonies.Select(x => new TestimonyHomeViewModel
			{
				Title = lang == "ar" ? x.DescriptionAr : x.Title,
				Description = lang == "ar" ? x.DescriptionAr : x.Description,
				UserName = x.UserName,
				UserJob = x.UserJob
			}).ToListAsync();

			var home = new HomeViewModel
			{
				Testimonies = testimonies,
				Rooms = rooms,
				Team = team
			};
			return View(home);
        }
    }
}
