using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpticalManagementSystemAPI.Models;

namespace OpticalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly AppDBContext _context;

        public PatientController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/patients | Get all patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return Ok(patients);
        }

        // GET: api/patients/[id] | Get patient by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return patient == null ? NotFound() : Ok(patient);
        }

        // POST: api/patients | Create new patient
        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        // DELETE: api/patients[id] | Delete patient with ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/patient[id] | Update patient
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, Patient updatedPatient)
        {
            if (id != updatedPatient.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            // Update all fields
            patient.FirstName = updatedPatient.FirstName;
            patient.LastName = updatedPatient.LastName;
            patient.DateOfBirth = updatedPatient.DateOfBirth;
            patient.PhoneNumber = updatedPatient.PhoneNumber;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Error updating patient.");
            }

            return NoContent();
        }
    }
}
