using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpticalManagementSystemAPI.DTOs;
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
        public async Task<ActionResult<IEnumerable<OptometristDTO>>> GetOptometrists()
        {
            // Load optometrists from the database as an EF entity, including the referenced entities.
            var optometrists = await _context.Optometrists
                .Include(o => o.Calendar)
                .ThenInclude(c => c.WorkingHours)
                .Include(o => o.Calendar.Appointments)
                .ToListAsync();

            var dtos = optometrists.Select(o => o.ToDTO()).ToList();
            return Ok(dtos);
        }

        // GET: api/optometrists/[id] | Get optometrist by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Optometrist>> GetOptometrist(int id)
        {
            // Load optometrist from the database as an EF entity, including the referenced entities.
            var optometrist = await _context.Optometrists
                .Include(o => o.Calendar)
                .ThenInclude(c => c.WorkingHours)
                .Include(o => o.Calendar.Appointments)
                .FirstOrDefaultAsync(o => o.Id == id);

            return optometrist == null ? NotFound() : Ok(optometrist.ToDTO());
        }

        // POST: api/optometrists | Create new optometrist
        [HttpPost]
        public async Task<ActionResult<OptometristCreateDTO>> CreateOptometrist(OptometristCreateDTO optomDTO)
        {
            var optometrist = new Optometrist
            {
                FirstName = optomDTO.FirstName,
                LastName = optomDTO.LastName
            };

            _context.Optometrists.Add(optometrist);
            await _context.SaveChangesAsync();

            var result = new
            {
                optometrist.Id,
                optometrist.FirstName,
                optometrist.LastName
            };

            return CreatedAtAction(nameof(GetOptometrist), new { id = optometrist.Id }, optometrist.ToDTO());
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
            // Check the given ID matches the given appointment
            if (id != updatedOptometrist.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            // Get the current optometrist with the given ID value
            var optometrist = await _context.Optometrists.FindAsync(id);
            if (optometrist == null)
                return NotFound();

            // Update all fields
            optometrist.FirstName = updatedOptometrist.FirstName;
            optometrist.LastName = updatedOptometrist.LastName;
            optometrist.Calendar = updatedOptometrist.Calendar;

            // Save to DB
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
