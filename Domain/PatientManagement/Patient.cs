using Domain.Common;
using Domain.Common.ValueObjects;

namespace Domain.PatientManagement;

public class Patient : AggregateRoot
{
    public static Patient Register(int id, string name, string lastName, string nationalCode, DateOnly birthDate, string phoneNumber)
    {
        //TODO: Should write validations

        return new Patient
        {
            Id = id,
            Name = new Name { First = name, Last = lastName },
            NationalCode = new NationalCode { Value = nationalCode },
            BirthDate = new BirthDate { Value = birthDate },
            PhoneNumber = new PhoneNumber { Value = phoneNumber },
        };
    }

    private Patient() { }

    public Name Name { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public BirthDate BirthDate { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
}