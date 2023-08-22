using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Admin.Models;
using App.Admin.ViewModels;
using MarminaAttendance.Identity;
using SnapatHotel.Models;

namespace App.Admin.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IdentityContext _context;

        public ReservationsController(IdentityContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,UserEmail,PhoneNumber,Status,Date,CreatedDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,UserEmail,PhoneNumber,Status,Date,CreatedDate")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'IdentityContext.Reservations'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> LoadReservations()
        {
            var draw = int.Parse(Request.Query["draw"]);
            var start = int.Parse(Request.Query["start"]);
            var length = int.Parse(Request.Query["length"]);
            var sortColumnIndex = int.Parse(Request.Query["order[0][column]"]);
            var sortColumnName = Request.Query[$"columns[{sortColumnIndex}][data]"];
            var sortDirection = Request.Query["order[0][dir]"];

            var searchValue = Request.Query["search[value]"];
            var statusFilter = Request.Query["columns[4][search][value]"]; 

            IQueryable<Reservation> query = _context.Reservations.AsQueryable();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(r =>
                    r.UserName.Contains(searchValue) ||
                    r.UserEmail.Contains(searchValue) ||
                    r.Status.ToString().Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                var isAnswered = statusFilter == ReservationStatus.Answered.ToString() ? ReservationStatus.Answered : ReservationStatus.Pending;
                query = query.Where(r => r.Status == isAnswered);
            }

            switch (sortColumnName)
            {
                case "id":
                    query = sortDirection == "asc"
                        ? query.OrderBy(r => r.Id)
                        : query.OrderByDescending(r => r.Id);
                    break;
                case "roomName":
                    query = sortDirection == "asc"
                        ? query.OrderBy(r => r.Room.NameEn)
                        : query.OrderByDescending(r => r.Room.NameEn);
                    break;
                
                case "userName":
                    query = sortDirection == "asc"
                        ? query.OrderBy(r => r.UserName)
                        : query.OrderByDescending(r => r.UserName);
                    break;
                case "userEmail":
                    query = sortDirection == "asc"
                        ? query.OrderBy(r => r.UserEmail)
                        : query.OrderByDescending(r => r.UserEmail);
                    break; 
                
                case "phoneNumber":
                    query = sortDirection == "asc"
                        ? query.OrderBy(r => r.PhoneNumber)
                        : query.OrderByDescending(r => r.PhoneNumber);
                    break; 
                
                case "date":
                    query = sortDirection == "asc"
                        ? query.OrderBy(r => r.Date)
                        : query.OrderByDescending(r => r.Date);
                    break;
                case "createdDate":
                    query = sortDirection == "asc"
                        ? query.OrderBy(r => r.CreatedDate)
                        : query.OrderByDescending(r => r.CreatedDate);
                    break;
                default:
                    query = query.OrderBy(r => r.Id); 
                    break;
            }

            var totalRecords = await query.CountAsync();

            var reservations = await query.Skip(start).Take(length).Include(x=>x.Room).Select(r=>new ReservationModel
            {
                Id = r.Id,
                RoomName = r.Room.NameEn,
                UserName = r.UserName,
                UserEmail = r.UserEmail,
                PhoneNumber = r.PhoneNumber,
                Status = r.Status.ToString(),
                Date = r.Date.ToString("MM/dd/yyyy hh:mm tt"),
                CreatedDate = r.CreatedDate.ToString("MM/dd/yyyy hh:mm tt")
            }).ToListAsync();

            var response = new
            {
                draw = draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords, 
                data = reservations
            };

            return Json(response);
        }
        public IActionResult ChangeStatus(int id)
        {
            var reservation = _context.Reservations.Find(id);

            if (reservation == null)
            {
                return NotFound();
            }

            reservation.Status = ReservationStatus.Answered;
            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }
    }
}
