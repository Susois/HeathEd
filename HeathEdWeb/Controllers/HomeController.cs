using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeathEdWeb.Models;
using HeathEdWeb.Data;

namespace HeathEdWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HeathEdDbContext _context;

    public HomeController(ILogger<HomeController> logger, HeathEdDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeViewModel
        {
            TotalStudents = await _context.Users.CountAsync(u => u.Role == "Student" && u.IsActive),
            TotalLecturers = await _context.Users.CountAsync(u => u.Role == "Lecturer" && u.IsActive),
            TotalModules = await _context.Modules.CountAsync(m => m.IsActive),
            TotalCases = await _context.CaseStudies.CountAsync(c => c.IsActive),

            RecentModules = await _context.Modules
                .Include(m => m.Lecturer)
                .Where(m => m.IsActive)
                .OrderByDescending(m => m.CreatedDate)
                .Take(5)
                .ToListAsync(),

            RecentCases = await _context.CaseStudies
                .Include(c => c.Module)
                .Where(c => c.IsActive)
                .OrderByDescending(c => c.CreatedDate)
                .Take(5)
                .ToListAsync()
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class HomeViewModel
{
    public int TotalStudents { get; set; }
    public int TotalLecturers { get; set; }
    public int TotalModules { get; set; }
    public int TotalCases { get; set; }
    public List<Module> RecentModules { get; set; } = new();
    public List<CaseStudy> RecentCases { get; set; } = new();
}
