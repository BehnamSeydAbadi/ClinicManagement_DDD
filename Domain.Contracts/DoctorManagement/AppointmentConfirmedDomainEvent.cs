using Domain.Contracts.Common;

namespace Domain.Contracts.DoctorManagement;

public class AppointmentConfirmedDomainEvent : DomainEvent
{
    public AppointmentConfirmedDomainEvent(int aggregateId, int appointmentId)
    {
        AggregateId = aggregateId;
        Id = appointmentId;
    }

    public int Id { get; }

    public override bool Equals(object? obj)
    {
        var that = obj as AppointmentConfirmedDomainEvent;

        return this.GetHashCode() == that.GetHashCode();
    }

    public override int GetHashCode() => $"{AggregateId}{Id}".GetHashCode();
}
