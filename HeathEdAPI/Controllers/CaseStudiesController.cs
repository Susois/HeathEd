using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeathEdAPI.Data;
using HeathEdAPI.Models;

namespace HeathEdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseStudiesController : ControllerBase
    {
        private readonly HeathEdDbContext _context;

        public CaseStudiesController(HeathEdDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseStudies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseStudy>>> GetCaseStudies()
        {
            return await _context.CaseStudies
                .Include(c => c.Module)
                .Where(c => c.IsActive)
                .ToListAsync();
        }

        // GET: api/CaseStudies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseStudy>> GetCaseStudy(int id)
        {
            var caseStudy = await _context.CaseStudies
                .Include(c => c.Module)
                .FirstOrDefaultAsync(c => c.CaseID == id);

            if (caseStudy == null)
            {
                return NotFound();
            }

            return caseStudy;
        }

        // GET: api/CaseStudies/module/1
        [HttpGet("module/{moduleId}")]
        public async Task<ActionResult<IEnumerable<CaseStudy>>> GetCaseStudiesByModule(int moduleId)
        {
            return await _context.CaseStudies
                .Include(c => c.Module)
                .Where(c => c.ModuleID == moduleId && c.IsActive)
                .ToListAsync();
        }

        // POST: api/CaseStudies
        [HttpPost]
        public async Task<ActionResult<CaseStudy>> CreateCaseStudy(CaseStudy caseStudy)
        {
            _context.CaseStudies.Add(caseStudy);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCaseStudy), new { id = caseStudy.CaseID }, caseStudy);
        }

        // PUT: api/CaseStudies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCaseStudy(int id, CaseStudy caseStudy)
        {
            if (id != caseStudy.CaseID)
            {
                return BadRequest();
            }

            _context.Entry(caseStudy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseStudyExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/CaseStudies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseStudy(int id)
        {
            var caseStudy = await _context.CaseStudies.FindAsync(id);
            if (caseStudy == null)
            {
                return NotFound();
            }

            // Soft delete
            caseStudy.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseStudyExists(int id)
        {
            return _context.CaseStudies.Any(e => e.CaseID == id);
        }
    }
}
