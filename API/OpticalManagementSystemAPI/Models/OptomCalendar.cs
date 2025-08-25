namespace OpticalManagementSystemAPI.Models
{
    public class OptomCalendar
    {
        public int Id { get; set; }

        // Reference to Optometrist
        public Optometrist? Optometrist { get; set; }
        public int OptomId { get; set; }

        // Length of an appointment slot
        public TimeSpan SlotLength { get; set; } = TimeSpan.FromMinutes(25);

        // List of working hours
        public List<WorkingHours>? WorkingHours { get; set; }

        // List of the appointments
        public List<Appointment>? Appointments { get; set; }
    }
}
