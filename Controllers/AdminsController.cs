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

        public AdminsController(IdentityContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
	        var admins = await _context.Admins.Include(x=>x.User).Select(x=> new AdminUser
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

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                await _context.Users.AddAsync(user);
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
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsRoot,CreatedDate")] Models.Admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
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

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Admins == null)
            {
                return Problem("Entity set 'IdentityContext.Admins'  is null.");
            }
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
          return (_context.Admins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
