using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Doctor;

internal class DoctorConfiguration : IEntityTypeConfiguration<DoctorDbEntity>
{
    internal static DoctorConfiguration Instance => new();
    private DoctorConfiguration() { }

    public void Configure(EntityTypeBuilder<DoctorDbEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(64).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(128).IsRequired();
        builder.Property(p => p.PhoneNumber).HasMaxLength(11).IsRequired();
    }
}
