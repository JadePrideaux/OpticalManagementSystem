namespace OpticalManagementSystemAPI.Models
{
    public class OptomCalendar
    {
        public int Id { get; set; }

        public required Optometrist Optometrist { get; set; }
        public int OptomId { get; set; }

        public TimeSpan SlotLength { get; set; } = TimeSpan.FromMinutes(25);
        public required List<Appointment> Appointments { get; set; } = new();
    }
}
