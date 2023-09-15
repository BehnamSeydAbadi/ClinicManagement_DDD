using Domain.Common;
using Domain.Common.ValueObjects;

namespace Domain.DoctorManagement;

public class Doctor : AggregateRoot
{
    public static Doctor Reconstitute(int id, string name, string lastName, string phoneNumber)
           => new()
           {
               Id = id,
               Name = new Name(name, lastName),
               PhoneNumber = new PhoneNumber(phoneNumber),
           };

    private Doctor() { }

    public Name Name { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
}
