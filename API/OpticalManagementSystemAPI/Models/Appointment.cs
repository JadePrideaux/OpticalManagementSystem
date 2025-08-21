namespace OpticalManagementSystemAPI.Models
{
    public class Appointment
    {
        public int id { get; set; }
        public required OptomCalendar Calendar { get; set; }
        public int CalenderId { get; set; }
        public DateTime? StartTime { get; set; }
        public Patient? Patient { get; set; }
        public int PatientId { get; set; }
    }
}
