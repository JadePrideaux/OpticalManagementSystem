namespace OpticalManagementSystemAPI.Models
{
    public class Optometrist
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public OptomCalendar Calendar { get; set; } = null!;

    }
}
