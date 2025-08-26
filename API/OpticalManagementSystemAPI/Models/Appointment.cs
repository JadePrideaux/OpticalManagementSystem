namespace OpticalManagementSystemAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        // Reference to Optom Calendar
        public int CalendarId { get; set; }
        public OptomCalendar? Calendar { get; set; }

        // Appointment start time
        public DateTime? StartTime { get; set; }

        // Reference to the patient
        public Patient? Patient { get; set; }
        public int PatientId { get; set; }
    }
}
