using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeathEdWeb.Data;
using HeathEdWeb.Models;

namespace HeathEdWeb.Controllers
{
    public class CaseStudiesController : Controller
    {
        private readonly HeathEdDbContext _context;

        public CaseStudiesController(HeathEdDbContext context)
        {
            _context = context;
        }

        // GET: CaseStudies
        public async Task<IActionResult> Index()
        {
            var cases = await _context.CaseStudies
                .Include(c => c.Module)
                .Where(c => c.IsActive)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
            return View(cases);
        }

        // GET: CaseStudies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseStudy = await _context.CaseStudies
                .Include(c => c.Module)
                    .ThenInclude(m => m.Lecturer)
                .FirstOrDefaultAsync(m => m.CaseID == id);

            if (caseStudy == null)
            {
                return NotFound();
            }

            return View(caseStudy);
        }

        // GET: CaseStudies/Create
        public IActionResult Create()
        {
            ViewBag.Modules = new SelectList(
                _context.Modules.Where(m => m.IsActive),
                "ModuleID", "ModuleName");
            return View();
        }

        // POST: CaseStudies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaseTitle,Description,Symptoms,Diagnosis,ModuleID")] CaseStudy caseStudy)
        {
            if (ModelState.IsValid)
            {
                caseStudy.CreatedDate = DateTime.Now;
                caseStudy.IsActive = true;
                _context.Add(caseStudy);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Đã tạo ca bệnh '{caseStudy.CaseTitle}' thành công!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Modules = new SelectList(
                _context.Modules.Where(m => m.IsActive),
                "ModuleID", "ModuleName", caseStudy.ModuleID);
            return View(caseStudy);
        }

        // GET: CaseStudies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseStudy = await _context.CaseStudies.FindAsync(id);
            if (caseStudy == null)
            {
                return NotFound();
            }

            ViewBag.Modules = new SelectList(
                _context.Modules.Where(m => m.IsActive),
                "ModuleID", "ModuleName", caseStudy.ModuleID);
            return View(caseStudy);
        }

        // POST: CaseStudies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaseID,CaseTitle,Description,Symptoms,Diagnosis,ModuleID,IsActive,CreatedDate")] CaseStudy caseStudy)
        {
            if (id != caseStudy.CaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseStudy);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = $"Đã cập nhật ca bệnh '{caseStudy.CaseTitle}' thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseStudyExists(caseStudy.CaseID))
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

            ViewBag.Modules = new SelectList(
                _context.Modules.Where(m => m.IsActive),
                "ModuleID", "ModuleName", caseStudy.ModuleID);
            return View(caseStudy);
        }

        // GET: CaseStudies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseStudy = await _context.CaseStudies
                .Include(c => c.Module)
                .FirstOrDefaultAsync(m => m.CaseID == id);
            if (caseStudy == null)
            {
                return NotFound();
            }

            return View(caseStudy);
        }

        // POST: CaseStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseStudy = await _context.CaseStudies.FindAsync(id);
            if (caseStudy != null)
            {
                // Soft delete
                caseStudy.IsActive = false;
                _context.Update(caseStudy);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Đã xóa ca bệnh '{caseStudy.CaseTitle}' thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CaseStudyExists(int id)
        {
            return _context.CaseStudies.Any(e => e.CaseID == id);
        }
    }
}
