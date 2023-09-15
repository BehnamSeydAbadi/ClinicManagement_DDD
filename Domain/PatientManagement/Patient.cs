using Domain.Common;
using Domain.Common.ValueObjects;
using Domain.Contracts.Patient;

namespace Domain.PatientManagement;

public class Patient : AggregateRoot
{
    private readonly List<Appointment> _appointments = new();

    private Patient() { }

    public static Patient Register(int id, string name, string lastName, string nationalCode, DateOnly birthDate, string phoneNumber)
    {
        //TODO: Should write validations

        var patient = new Patient
        {
            Id = id,
            Name = new Name(name, lastName),
            NationalCode = new NationalCode(nationalCode),
            BirthDate = new BirthDate(birthDate),
            PhoneNumber = new PhoneNumber(phoneNumber),
        };

        patient._domainEvents.Enqueue(new PatientRegisteredDomainEvent
        {
            AggregateId = id,
            Name = name,
            LastName = lastName,
            NationalCode = nationalCode,
            BirthDate = birthDate,
            PhoneNumber = phoneNumber,
        });

        return patient;
    }

    public static Patient Reconstitute(int id, string name, string lastName, string nationalCode, DateOnly birthDate, string phoneNumber)
           => new()
           {
               Id = id,
               Name = new Name(name, lastName),
               NationalCode = new NationalCode(nationalCode),
               BirthDate = new BirthDate(birthDate),
               PhoneNumber = new PhoneNumber(phoneNumber),
           };



    public void ScheduleAppointment(int id, int doctorId, int durationMinutes, DateTime startDateTime)
    {
        var appointment = Appointment.Schedule(id, doctorId, durationMinutes, startDateTime);

        _appointments.Add(appointment);

        _domainEvents.Enqueue(new AppointmentScheduledDomainEvent
        {
            AggregateId = Id,
            Id = appointment.Id,
            DoctorId = doctorId,
            DurationMinutes = durationMinutes,
            StartDateTime = startDateTime
        });
    }

    public IEnumerable<Appointment> GetAppointments() => _appointments.AsReadOnly();


    public Name Name { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public BirthDate BirthDate { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
}