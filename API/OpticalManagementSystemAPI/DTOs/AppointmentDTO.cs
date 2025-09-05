namespace OpticalManagementSystemAPI.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
