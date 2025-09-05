namespace OpticalManagementSystemAPI.DTOs
{
    public class OptometristCalendarDTO
    {
        public int Id { get; set; }

        // Length of an appointment slot
        public TimeSpan SlotLength { get; set; } = TimeSpan.FromMinutes(25);

        // List of working hours
        public List<WorkingHoursDTO>? WorkingHours { get; set; }

        // List of the appointments
        public List<AppointmentDTO>? Appointments { get; set; }
    }
}
