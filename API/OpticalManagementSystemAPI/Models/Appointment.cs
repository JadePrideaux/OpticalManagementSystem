namespace OpticalManagementSystemAPI.Models
{
    public class Appointment
    {
        public int id { get; set; }

        // Reference to Optom Calendar
        public int CalenderId { get; set; }
        public OptomCalendar? Calendar { get; set; }

        // Appointment start time
        public DateTime? StartTime { get; set; }

        // Reference to the patient
        public Patient? Patient { get; set; }
        public int PatientId { get; set; }
    }
}
