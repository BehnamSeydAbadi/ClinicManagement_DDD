using Domain.Common;

namespace Domain.DoctorManagement;

public class Appointment : Entity
{
    private Appointment() { }

    public static Appointment Reconstitute(int id, int patientId, int durationMinutes, DateTime startDateTime, bool isConfirmed)
           => new()
           {
               Id = id,
               PatientId = patientId,
               DurationMinutes = durationMinutes,
               StartDateTime = startDateTime,
               IsConfirmed = isConfirmed,
           };

    internal void Confirm()
    {
        //TODO: Validate it's not confiremd before

        IsConfirmed = true;
    }

    public int PatientId { get; private set; }
    public int DurationMinutes { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public bool IsConfirmed { get; private set; }
}
