using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Doctor;

internal class DoctorConfiguration : IEntityTypeConfiguration<DoctorDbEntity>
{
    internal static DoctorConfiguration Instance => new();
    private DoctorConfiguration() { }

    public void Configure(EntityTypeBuilder<DoctorDbEntity> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).HasMaxLength(64).IsRequired();
        builder.Property(d => d.LastName).HasMaxLength(128).IsRequired();
        builder.Property(d => d.PhoneNumber).HasMaxLength(11).IsRequired();
        builder.Property(d => d.Type).HasConversion<int>().IsRequired();
    }
}
