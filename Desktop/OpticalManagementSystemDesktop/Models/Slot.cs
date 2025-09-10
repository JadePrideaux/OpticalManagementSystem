namespace OpticalManagementSystemDesktop.Models
{
    // Class to represent a slot on the frontend
    public class Slot
    {
        public DateTime StartTime { get; set; }
        public Appointment? Appointment { get; set; }
        public bool IsBooked => Appointment != null;
    }
}
