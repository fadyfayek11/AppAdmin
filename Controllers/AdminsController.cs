using App.Admin.Identity;
using App.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarminaAttendance.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Admin.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IdentityContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
		public AdminsController(IdentityContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

        public async Task<IActionResult> Index()
        {
			var currentUser = await _userManager.GetUserAsync(User);

			if (currentUser != null)
			{
				var admins = await _context.Admins.Include(x => x.User).Where(x => x.User.Id != currentUser.Id).Select(x => new AdminUser
				{
					Id = x.User.Id,
					Name = x.User.UserName,
					Email = x.User.Email,
					Mobile = x.User.PhoneNumber,
					CreationDate = x.CreatedDate,
					IsRoot = x.IsRoot,
				}).ToListAsync();

				return View(admins);
			}

			return LocalRedirect("/Account/Login");
		}

        

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminUser admin)
        {
            if (ModelState.IsValid)
            {
                var hasher = new PasswordHasher<ApplicationUser>();
                var user = new ApplicationUser()
                {
                    UserName = admin.Name,
                    NormalizedUserName = admin.Name.ToUpper(),
                    Email = admin.Email,
                    NormalizedEmail = admin.Email.ToUpper(),
                    PhoneNumber = admin.Mobile,
                    PasswordHash = hasher.HashPassword(null, admin.Password)
                };

				await _userManager.CreateAsync(user);
				await _userManager.AddToRoleAsync(user,admin.IsRoot? "RootAdmin" : "Admin");

				await _context.Admins.AddAsync(new Models.Admin
                { 
                    IsRoot = admin.IsRoot,
                    CreatedDate = DateTime.Now,
                    User = user
                });

                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {
					return View(admin); 
                }
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

			var admin = await _context.Admins.Include(x => x.User).Select(x => new AdminUser
			{
				Id = x.User.Id,
				Name = x.User.UserName,
				Email = x.User.Email,
				Mobile = x.User.PhoneNumber,
				CreationDate = x.CreatedDate,
				IsRoot = x.IsRoot,
			}).Where(x=>x.Id == id).FirstOrDefaultAsync();
			if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, AdminUser admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
	                var adminUser = await _context.Admins.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Id == id);
                   
	                if(adminUser is null) return NotFound();
                    adminUser.IsRoot = admin.IsRoot;

                    _context.Admins.Update(adminUser);

                    var hasher = new PasswordHasher<ApplicationUser>();

                    adminUser.User.Email = admin.Email;
                    adminUser.User.NormalizedEmail = admin.Email.ToUpper();
                    adminUser.User.PhoneNumber = admin.Mobile;
                    adminUser.User.UserName = admin.Name;
                    adminUser.User.NormalizedEmail = admin.Name.ToUpper();
                    adminUser.User.PasswordHash = string.IsNullOrEmpty(admin.Password) ? adminUser.User.PasswordHash : admin.Password;

                    _context.Users.Update(adminUser.User);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
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
            return View(admin);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Admins == null)
            {
                return Json(new { success = false });
            }
            var admin = await _context.Admins.Include(x=>x.User).Where(x=>x.User.Id == id).FirstOrDefaultAsync();
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.Users.Remove(admin.User);
            }
            
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        private bool AdminExists(string id)
        {
          return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
