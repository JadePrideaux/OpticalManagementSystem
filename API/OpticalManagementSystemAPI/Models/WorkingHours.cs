namespace OpticalManagementSystemAPI.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }

        // Reference to calendar
        public int OptomCalendarId { get; set; }
        public OptomCalendar? Calendar { get; set; } = null!;

        // Day of the week
        public DayOfWeek Day { get; set; }

        // Start & End times
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
