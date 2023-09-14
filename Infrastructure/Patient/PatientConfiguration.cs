using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Patient;

internal class PatientConfiguration : IEntityTypeConfiguration<PatientDbEntity>
{
    internal static PatientConfiguration Instance => new();
    private PatientConfiguration() { }

    public void Configure(EntityTypeBuilder<PatientDbEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(64).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(128).IsRequired();
        builder.Property(p => p.NationalCode).HasMaxLength(10).IsRequired();
        builder.Property(p => p.BirthDate).IsRequired();
        builder.Property(p => p.PhoneNumber).HasMaxLength(11).IsRequired();
    }
}
