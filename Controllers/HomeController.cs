﻿using App.Admin.Models;
using App.Admin.ViewModels;
using MarminaAttendance.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Controllers
{
    public class HomeController : Controller
	{
		private readonly IdentityContext _context;

		public HomeController(IdentityContext context)
		{
			_context = context;
		}
		
		public async Task<IActionResult> Index()
        {
	        var langCookie = Request.Cookies["language"];
	        var lang = string.IsNullOrEmpty(langCookie) ? "en" : langCookie;

			var rooms = await _context.Rooms
				.Take(6)
                .Where(x=>x.IsAvailable)
				.Select(x=>new RoomsHomeViewModel
				{
					RoomId = x.Id,
					Name = lang == "ar" ? x.NameAr : x.NameEn,
					Description = lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
					CoverImagePath = x.CoverImagePath,
					Price = x.Price
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

		[HttpGet]
		public async Task<IActionResult> PreviewRoom(int id)
		{
            var langCookie = Request.Cookies["language"];
            var lang = string.IsNullOrEmpty(langCookie) ? "en" : langCookie;

            var room = await _context.Rooms.Include(x => x.RoomDetails)!
				.ThenInclude(x => x.DetailsDescription)
				.Include(x => x.RoomImages)
				.Where(x => x.Id == id && x.IsAvailable)
                .Select(x=>new RoomHomeViewModel
                {
                    RoomId = x.Id,
                    Name = lang == "ar" ? x.NameAr : x.NameEn,
                    Description = lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
                    CoverImagePath = x.CoverImagePath,
                    Price = x.Price,
                    Size = x.Size,
                    MaxOccupancy = x.MaxOccupancy,
                    AllowSmoking = x.AllowSmoking,
                    RoomDetails = x.RoomDetails.Select(y=> new RoomDetailsHomeViewModel
                    {
                        DetailName = lang == "ar" ? y.DetailNameAr : y.DetailNameEn,
                        IsIcon = y.IsIcon,
                        RoomId = y.RoomId,
                        DetailsDescription = y.DetailsDescription.Select(z=> new DetailsDescriptionHomeViewModel
                        {
                            Description = z.IsIcon ? z.DescriptionEn : lang == "ar" ? z.DescriptionAr : z.DescriptionEn,
                            IsIcon = z.IsIcon,
                            RoomDetailsId = z.RoomDetailsId,
                        }).ToList(),
                    }).ToList(),
                    RoomImages = x.RoomImages.Select(i=>new RoomImagesHomeViewModel
                    {
                        Path = i.Path,
                        RoomId = i.RoomId,
                    }).ToList(),
                })
                .FirstOrDefaultAsync();
			if (room == null)
			{
				return NotFound();
			}
			return View(room);
		}

		[HttpGet]
		public async Task<IActionResult> Rooms()
		{
			var langCookie = Request.Cookies["language"];
			var lang = string.IsNullOrEmpty(langCookie) ? "en" : langCookie;

			var rooms = await _context.Rooms
				.Where(x => x.IsAvailable)
				.Select(x => new RoomsHomeViewModel
				{
					RoomId = x.Id,
					Name = lang == "ar" ? x.NameAr : x.NameEn,
					Description = lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
					CoverImagePath = x.CoverImagePath,
					Price = x.Price
				}).ToListAsync();
			return View(rooms);
		}

		public async Task<IActionResult> About()
        {
            var langCookie = Request.Cookies["language"];
            var lang = string.IsNullOrEmpty(langCookie) ? "en" : langCookie;

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
                Rooms = null,
                Team = team
            };
            return View(home);
		}

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> News(int page = 1, int pageSize = 10)
        {
            var langCookie = Request.Cookies["language"];
            var lang = string.IsNullOrEmpty(langCookie) ? "en" : langCookie;

            var totalCountNews = await _context.News.CountAsync();
            var news = await _context.News
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(x=>x.DatePublished)
                .Select(x=> new NewsVM
                {
                    Id = x.Id,
                    Title = lang == "ar" ? x.TitleAr : x.Title,
                    CoverImagePath = x.CoverImagePath,
                    Content = lang == "ar" ? x.ContentAr : x.ContentEn ,
                    DatePublished = x.DatePublished.ToString("dddd, dd MMMM yyyy"),
                })
                .ToListAsync();

            var pageInfo = new PageInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = totalCountNews
            };

            var viewModel = new NewsViewModel
            {
                NewsArticles = news,
                PageInfo = pageInfo
            };
            return View(viewModel);
        }

        public async Task<IActionResult> PreviewNews(int newsId)
        {
	        var langCookie = Request.Cookies["language"];
	        var lang = string.IsNullOrEmpty(langCookie) ? "en" : langCookie;

			var news = await _context.News
		        .Where(x=>x.Id == newsId)
		        .Select(x => new NewsVM
		        {
			        Id = x.Id,
			        Title = lang == "ar" ? x.TitleAr : x.Title,
			        CoverImagePath = x.CoverImagePath,
			        Content = lang == "ar" ? x.ContentAr : x.ContentEn,
			        DatePublished = x.DatePublished.ToString("dddd, dd MMMM yyyy"),
		        }).FirstOrDefaultAsync();
		        
			return View(news);
        }

	}
}
