using Domain.Common;
using Domain.Common.ValueObjects;

namespace Domain.PatientManagement;

public class Patient : AggregateRoot
{
    private readonly List<Appointment> _appointments = new();

    private Patient() { }

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

    public static Patient Reconstitute(int id, string name, string lastName, string nationalCode, DateOnly birthDate, string phoneNumber)
           => new()
           {
               Id = id,
               Name = new Name { First = name, Last = lastName },
               NationalCode = new NationalCode { Value = nationalCode },
               BirthDate = new BirthDate { Value = birthDate },
               PhoneNumber = new PhoneNumber { Value = phoneNumber },
           };



    public void ScheduleAppointment(int id, int doctorId, int durationMinutes, DateTime startDateTime)
    {
        var appointment = Appointment.Schedule(id, doctorId, durationMinutes, startDateTime);
        _appointments.Add(appointment);

        //TODO: Raise an event
    }

    public IEnumerable<Appointment> GetAppointments() => _appointments.AsReadOnly();

    public Name Name { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public BirthDate BirthDate { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
}