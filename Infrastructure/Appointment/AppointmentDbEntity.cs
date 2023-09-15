using Infrastructure.Common;
using Infrastructure.Doctor;
using Infrastructure.Patient;

namespace Infrastructure.Appointment;

public sealed class AppointmentDbEntity : BaseDbEntity
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int DurationMinutes { get; set; }
    public DateTime StartDateTime { get; set; }
    public bool IsConfirmed { get; set; }


    public PatientDbEntity Patient { get; set; }
    public DoctorDbEntity Doctor { get; set; }
}
