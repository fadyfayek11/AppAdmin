using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
	public class DashboardController : Controller
	{
		[Authorize(Roles = "Admin, RootAdmin")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
