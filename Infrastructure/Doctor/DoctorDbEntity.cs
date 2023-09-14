using Infrastructure.Common;

namespace Infrastructure.Doctor;

public sealed record DoctorDbEntity : BaseDbEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}
