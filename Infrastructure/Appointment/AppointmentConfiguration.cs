using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Appointment;

internal class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentDbEntity>
{
    internal static AppointmentConfiguration Instance => new();
    private AppointmentConfiguration() { }

    public void Configure(EntityTypeBuilder<AppointmentDbEntity> builder)
    {
        throw new NotImplementedException();
    }
}
