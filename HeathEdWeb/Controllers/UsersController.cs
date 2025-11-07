using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeathEdWeb.Data;
using HeathEdWeb.Models;

namespace HeathEdWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly HeathEdDbContext _context;

        public UsersController(HeathEdDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string role = "")
        {
            var users = _context.Users.Where(u => u.IsActive);

            if (!string.IsNullOrEmpty(role))
            {
                users = users.Where(u => u.Role == role);
                ViewBag.FilterRole = role;
            }

            return View(await users.OrderBy(u => u.UserID).ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.ModulesAsLecturer)
                .Include(u => u.StudentModules)
                    .ThenInclude(sm => sm.Module)
                .FirstOrDefaultAsync(m => m.UserID == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,FullName,Email,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                user.CreatedDate = DateTime.Now;
                user.IsActive = true;
                _context.Add(user);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Đã tạo người dùng '{user.FullName}' thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,Username,Password,FullName,Email,Role,CreatedDate,IsActive")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = $"Đã cập nhật người dùng '{user.FullName}' thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                // Soft delete
                user.IsActive = false;
                _context.Update(user);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Đã xóa người dùng '{user.FullName}' thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
