using Domain.Contracts.Common;

namespace Domain.Contracts.DoctorManagement.Events;

public class AGeneralPractitionerHiredDomainEvent : DomainEvent
{
    public string Name { get; }
    public string LastName { get; }
    public string PhoneNumber { get; }

    public AGeneralPractitionerHiredDomainEvent(
           int id, string name, string lastName, string phoneNumber)
    {
        AggregateId = id;
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    public override bool Equals(object? obj)
    {
        var that = obj as AGeneralPractitionerHiredDomainEvent;

        return this.GetHashCode() == that.GetHashCode();
    }
    public override int GetHashCode() => $"{AggregateId}{Name}{LastName}{PhoneNumber}".GetHashCode();
}
