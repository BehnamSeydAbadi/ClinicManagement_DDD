using Infrastructure.Appointment;
using Infrastructure.Doctor;
using Infrastructure.Patient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(PatientConfiguration.Instance);
            modelBuilder.ApplyConfiguration(DoctorConfiguration.Instance);
            modelBuilder.ApplyConfiguration(AppointmentConfiguration.Instance);
        }

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        public DbSet<PatientDbEntity> Patients { get; set; }
        public DbSet<DoctorDbEntity> Doctors { get; set; }
        public DbSet<AppointmentDbEntity> Appointments { get; set; }
    }
}
