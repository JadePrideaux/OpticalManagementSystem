namespace OpticalManagementSystemAPI.DTOs
{
    public class OptometristDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public OptometristCalendarDTO? Calendar { get; set; }
    }
}
