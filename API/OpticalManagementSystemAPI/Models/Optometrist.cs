namespace OpticalManagementSystemAPI.Models
{
    public class Optometrist
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public OptomCalendar Calendar { get; set; } = null!;

        public Optometrist()
        {
            Calendar = new OptomCalendar
            {
                SlotLength = TimeSpan.FromMinutes(25),
                WorkingHours = GetDefaultWorkingHours(),
                Appointments = new List<Appointment>()
            };
        }

        private List<WorkingHours> GetDefaultWorkingHours()
        {
            var defaults = new List<WorkingHours>();

            for (int i = (int)DayOfWeek.Monday; i <= (int)DayOfWeek.Friday; i++)
            {
                defaults.Add(new WorkingHours
                {
                    Day = (DayOfWeek)i,
                    Start = new TimeSpan(9, 0, 0),
                    End = new TimeSpan(17, 0, 0)
                });
            }
            return defaults;
        }
    }
}
