using Microsoft.EntityFrameworkCore;

namespace OpticalManagementSystemAPI.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; } = null!;
    }
}
