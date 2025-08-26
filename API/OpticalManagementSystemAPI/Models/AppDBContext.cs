using Microsoft.EntityFrameworkCore;

namespace OpticalManagementSystemAPI.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        // Add models
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Optometrist> Optometrists { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<WorkingHours> WorkingHours { get; set; } = null!;
        public DbSet<OptomCalendar> OptomCalenders { get; set; } = null!;

        // Relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Optometrist>()
                .HasOne(o => o.Calendar)
                .WithOne(c => c.Optometrist)
                .HasForeignKey<OptomCalendar>(c => c.OptomId);
        }
    }
}
