using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpticalManagementSystemAPI.DTOs;
using OpticalManagementSystemAPI.Models;

namespace OpticalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OptomCalendarController : Controller
    {
        private readonly AppDBContext _context;

        public OptomCalendarController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/optomcalendar/[id]/appointments?date=YYYY-MM-DD
        // Get all appointments on one optom's calendar for a set date
        [HttpGet("{id}/appointments")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsForDate(
            int id, [FromQuery] DateTime? date)
        {
            var calendar = await _context.OptomCalenders
                .Include(c => c.WorkingHours)
                .Include(c => c.Appointments)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (calendar == null) return NotFound();

            var appointments = calendar.Appointments
                .Where(a => !date.HasValue ||
                    (a.StartTime >= date.Value.Date && a.StartTime < date.Value.Date.AddDays(1)))
                .Select(a => new AppointmentDTO
                {
                    Id = a.Id,
                    StartTime = a.StartTime!.Value,
                    PatientId = a.PatientId
                })
                .ToList();

            return Ok(appointments.ToList());
        }
    }
}
