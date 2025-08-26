using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpticalManagementSystemAPI.Models;

namespace OpticalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly AppDBContext _context;

        public AppointmentController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/appointments/[id] | Get appointment by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            return appointment == null ? NotFound() : Ok(appointment);
        }

        // POST: api/appointments | Create new appointment
        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(Appointment appointment)
        {
            // Check patient exists
            var patient = await _context.Patients.FindAsync(appointment.PatientId);
            if (patient == null) return BadRequest("Patient not found!");

            // Check calendar exists
            var calendar = await _context.OptomCalenders
                                 .Include(c => c.WorkingHours)
                                 .Include(c => c.Appointments)
                                 .FirstOrDefaultAsync(c => c.Id == appointment.CalendarId);

            if (calendar == null) return BadRequest("Calendar not found!");

            // Check new appointment is within the calenars working hours
            if (appointment.StartTime == null)
                return BadRequest("StartTime is required.");

            if (calendar.WorkingHours == null || calendar.WorkingHours.Count == 0)
                return BadRequest("No working hours defined for this calendar!");

            var workingDay = calendar.WorkingHours.FirstOrDefault(
                wh => wh.Day == appointment.StartTime.Value.DayOfWeek);

            if (workingDay == null)
                return BadRequest("No working hours defined for this day!");

            // Check the slot is available
            if (calendar.Appointments != null)
            {
                var slotTaken = calendar.Appointments.Any(a => a.StartTime == appointment.StartTime);
                if (slotTaken) return BadRequest("Appointment slot already taken.");
            }

            // Save appointment
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        // DELETE: api/appointment[id] | Delete appointment with given ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            // Get appointment with given ID
            var appointment = await _context.Appointments.FindAsync(id);

            // If no appointment with the given ID is found, return not found
            if (appointment == null)
                return NotFound();

            // Remove the appointment from the table and sync changes
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/appointment[id] | Update appointment with given ID and an updatedAppointment object
        [HttpPut]
        public async Task<ActionResult> UpdateAppointment(int id, Appointment updatedAppointment)
        {
            // Check the given ID matches the given appointment
            if (id != updatedAppointment.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            // Get the current appointment with the given ID value
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            // Update relevant fields
            appointment.StartTime = updatedAppointment.StartTime;
            appointment.PatientId = updatedAppointment.PatientId;
            appointment.CalendarId = updatedAppointment.CalendarId;

            // Save to DB
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Error updating appointment.");
            }

            return NoContent();
        }
    }
}
