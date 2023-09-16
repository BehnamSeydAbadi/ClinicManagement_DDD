using Domain.Contracts.DoctorManagement.Enums;
using Infrastructure.Appointment;
using Infrastructure.Common;

namespace Infrastructure.Doctor;

public sealed class DoctorDbEntity : BaseDbEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DoctorType Type { get; set; }

    public List<AppointmentDbEntity> Appointments { get; set; }
}
