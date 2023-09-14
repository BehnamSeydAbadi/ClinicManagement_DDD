using Domain.Common;

namespace Domain.PatientManagement;

public class Appointment : Entity
{
    public int DoctorId { get; private set; }
    public int DurationMinutes { get; private set; }
    public DateTime StartDateTime { get; private set; }

    internal static Appointment Schedule(int id, int doctorId, int durationMinutes, DateTime startDateTime)
    {
        //TODO: Should write business logic

        return new()
        {
            Id = id,
            DoctorId = doctorId,
            DurationMinutes = durationMinutes,
            StartDateTime = startDateTime
        };
    }

    private Appointment() { }
}
