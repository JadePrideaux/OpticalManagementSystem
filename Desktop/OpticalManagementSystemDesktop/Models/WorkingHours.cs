namespace OpticalManagementSystemDesktop.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }

        // Start & End times
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
