using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Appointment;

internal class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentDbEntity>
{
    internal static AppointmentConfiguration Instance => new();
    private AppointmentConfiguration() { }

    public void Configure(EntityTypeBuilder<AppointmentDbEntity> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.Patient).WithMany(p => p.Appointments).HasForeignKey(a => a.PatientId);
        builder.HasOne(a => a.Doctor).WithMany(d => d.Appointments).HasForeignKey(a => a.DoctorId);
    }
}
