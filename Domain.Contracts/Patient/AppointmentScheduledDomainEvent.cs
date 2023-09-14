using Domain.Contracts.Common;

namespace Domain.Contracts.Patient;

public class AppointmentScheduledDomainEvent : DomainEvent
{
    public int Id { get; init; }
    public int DoctorId { get; init; }
    public int DurationMinutes { get; init; }
    public DateTime StartDateTime { get; init; }
}
