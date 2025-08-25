using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpticalManagementSystemAPI.Models;

namespace OpticalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OptometristController : Controller
    {
        private readonly AppDBContext _context;

        public OptometristController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/optometrists | Get all optometrists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Optometrist>>> GetOptometrists()
        {
            var optometrists = await _context.Optometrists.ToListAsync();
            return Ok(optometrists);
        }

        // GET: api/optometrists/[id] | Get optometrist by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Optometrist>> GetOptometrist(int id)
        {
            var optometrist = await _context.Optometrists.FindAsync(id);
            return optometrist == null ? NotFound() : Ok(optometrist);
        }

        // POST: api/optometrists | Create new optometrist
        [HttpPost]
        public async Task<ActionResult<Optometrist>> CreateOptometrist(Optometrist optometrist)
        {
            _context.Optometrists.Add(optometrist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOptometrist), new { id = optometrist.Id }, optometrist);
        }

        // DELETE: api/optometrists[id] | Delete optometrist with ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOptometrist(int id)
        {
            var optometrist = await _context.Optometrists.FindAsync(id);

            if (optometrist == null)
            {
                return NotFound();
            }

            _context.Optometrists.Remove(optometrist);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/optometrist[id] | Update optometrist
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOptometrist(int id, Optometrist updatedOptometrist)
        {
            if (id != updatedOptometrist.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            var optometrist = await _context.Optometrists.FindAsync(id);

            if (optometrist == null)
            {
                return NotFound();
            }

            // Update all fields
            optometrist.FirstName = updatedOptometrist.FirstName;
            optometrist.LastName = updatedOptometrist.LastName;
            optometrist.Calendar = updatedOptometrist.Calendar;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Error updating optometrist.");
            }

            return NoContent();
        }
    }
}
