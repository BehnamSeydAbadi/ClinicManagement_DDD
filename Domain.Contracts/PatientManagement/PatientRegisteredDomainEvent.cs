using Domain.Contracts.Common;

namespace Domain.Contracts.PatientManagement;

public class PatientRegisteredDomainEvent : DomainEvent
{
    public string Name { get; init; }
    public string LastName { get; init; }
    public string NationalCode { get; init; }
    public DateOnly BirthDate { get; init; }
    public string PhoneNumber { get; init; }
}
