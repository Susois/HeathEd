using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeathEdAPI.Data;
using HeathEdAPI.Models;

namespace HeathEdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly HeathEdDbContext _context;

        public ModulesController(HeathEdDbContext context)
        {
            _context = context;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModules()
        {
            return await _context.Modules
                .Include(m => m.Lecturer)
                .Where(m => m.IsActive)
                .ToListAsync();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetModule(int id)
        {
            var module = await _context.Modules
                .Include(m => m.Lecturer)
                .Include(m => m.CaseStudies)
                .FirstOrDefaultAsync(m => m.ModuleID == id);

            if (module == null)
            {
                return NotFound();
            }

            return module;
        }

        // GET: api/Modules/lecturer/1
        [HttpGet("lecturer/{lecturerId}")]
        public async Task<ActionResult<IEnumerable<Module>>> GetModulesByLecturer(int lecturerId)
        {
            return await _context.Modules
                .Include(m => m.Lecturer)
                .Where(m => m.LecturerID == lecturerId && m.IsActive)
                .ToListAsync();
        }

        // POST: api/Modules
        [HttpPost]
        public async Task<ActionResult<Module>> CreateModule(Module module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetModule), new { id = module.ModuleID }, module);
        }

        // PUT: api/Modules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(int id, Module module)
        {
            if (id != module.ModuleID)
            {
                return BadRequest();
            }

            _context.Entry(module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            // Soft delete
            module.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.ModuleID == id);
        }
    }
}
