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
        }

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        public DbSet<PatientDbEntity> Patients { get; set; }
    }
}
