namespace OpticalManagementSystemAPI.DTOs
{
    public class WorkingHoursDTO
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
