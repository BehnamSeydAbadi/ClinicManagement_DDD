using Infrastructure.Appointment;
using Infrastructure.Common;

namespace Infrastructure.Patient;

public sealed class PatientDbEntity : BaseDbEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }

    public List<AppointmentDbEntity> Appointments { get; set; }
}
