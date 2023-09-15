using Domain.Common;
using Domain.Common.ValueObjects;
using Domain.Contracts.DoctorManagement;

namespace Domain.DoctorManagement;

public class Doctor : AggregateRoot
{
    private readonly List<Appointment> _appointments = new();

    public static Doctor Reconstitute(
           int id, string name, string lastName, string phoneNumber,
           IEnumerable<Appointment> appointments)
    {
        var doctor = new Doctor()
        {
            Id = id,
            Name = new Name(name, lastName),
            PhoneNumber = new PhoneNumber(phoneNumber),
        };

        doctor._appointments.AddRange(appointments);

        return doctor;
    }

    public void ConfirmAppointment(int appointmentId)
    {
        var appointment = _appointments.Single(a => a.Id == appointmentId);
        appointment.Confirm();
        Enqueue(new AppointmentConfirmedDomainEvent(Id, appointmentId));
    }

    public IReadOnlyList<Appointment> GetAppointments()
           => _appointments.ToList().AsReadOnly();

    private Doctor() { }

    public Name Name { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
}
