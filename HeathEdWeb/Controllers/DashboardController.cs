using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeathEdWeb.Data;
using HeathEdWeb.Models;

namespace HeathEdWeb.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HeathEdDbContext _context;

        public DashboardController(HeathEdDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard
        public async Task<IActionResult> Index()
        {
            var stats = new DashboardViewModel
            {
                TotalStudents = await _context.Users.CountAsync(u => u.Role == "Student" && u.IsActive),
                TotalLecturers = await _context.Users.CountAsync(u => u.Role == "Lecturer" && u.IsActive),
                TotalModules = await _context.Modules.CountAsync(m => m.IsActive),
                TotalCases = await _context.CaseStudies.CountAsync(c => c.IsActive)
            };

            return View(stats);
        }

        // GET: Dashboard/Students
        public async Task<IActionResult> Students()
        {
            var students = await _context.Users
                .Where(u => u.Role == "Student" && u.IsActive)
                .ToListAsync();

            return View(students);
        }

        // GET: Dashboard/Modules
        public async Task<IActionResult> Modules()
        {
            var modules = await _context.Modules
                .Include(m => m.Lecturer)
                .Where(m => m.IsActive)
                .ToListAsync();

            return View(modules);
        }

        // GET: Dashboard/Cases
        public async Task<IActionResult> Cases()
        {
            var cases = await _context.CaseStudies
                .Include(c => c.Module)
                .Where(c => c.IsActive)
                .ToListAsync();

            return View(cases);
        }
    }

    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }
        public int TotalLecturers { get; set; }
        public int TotalModules { get; set; }
        public int TotalCases { get; set; }
    }
}
