using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeathEdWeb.Data;
using HeathEdWeb.Models;

namespace HeathEdWeb.Controllers
{
    public class ModulesController : Controller
    {
        private readonly HeathEdDbContext _context;

        public ModulesController(HeathEdDbContext context)
        {
            _context = context;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {
            var modules = await _context.Modules
                .Include(m => m.Lecturer)
                .Where(m => m.IsActive)
                .OrderBy(m => m.ModuleCode)
                .ToListAsync();
            return View(modules);
        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.Modules
                .Include(m => m.Lecturer)
                .Include(m => m.StudentModules)
                    .ThenInclude(sm => sm.Student)
                .Include(m => m.CaseStudies.Where(c => c.IsActive))
                .FirstOrDefaultAsync(m => m.ModuleID == id);

            if (module == null)
            {
                return NotFound();
            }

            return View(module);
        }

        // GET: Modules/Create
        public IActionResult Create()
        {
            ViewBag.Lecturers = new SelectList(
                _context.Users.Where(u => u.Role == "Lecturer" && u.IsActive),
                "UserID", "FullName");
            return View();
        }

        // POST: Modules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModuleCode,ModuleName,Description,LecturerID")] Module module)
        {
            if (ModelState.IsValid)
            {
                module.CreatedDate = DateTime.Now;
                module.IsActive = true;
                _context.Add(module);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Đã tạo môn học '{module.ModuleName}' thành công!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Lecturers = new SelectList(
                _context.Users.Where(u => u.Role == "Lecturer" && u.IsActive),
                "UserID", "FullName", module.LecturerID);
            return View(module);
        }

        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            ViewBag.Lecturers = new SelectList(
                _context.Users.Where(u => u.Role == "Lecturer" && u.IsActive),
                "UserID", "FullName", module.LecturerID);
            return View(module);
        }

        // POST: Modules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModuleID,ModuleCode,ModuleName,Description,LecturerID,IsActive,CreatedDate")] Module module)
        {
            if (id != module.ModuleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(module);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = $"Đã cập nhật môn học '{module.ModuleName}' thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(module.ModuleID))
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

            ViewBag.Lecturers = new SelectList(
                _context.Users.Where(u => u.Role == "Lecturer" && u.IsActive),
                "UserID", "FullName", module.LecturerID);
            return View(module);
        }

        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.Modules
                .Include(m => m.Lecturer)
                .FirstOrDefaultAsync(m => m.ModuleID == id);
            if (module == null)
            {
                return NotFound();
            }

            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module != null)
            {
                // Soft delete
                module.IsActive = false;
                _context.Update(module);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Đã xóa môn học '{module.ModuleName}' thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.ModuleID == id);
        }
    }
}
