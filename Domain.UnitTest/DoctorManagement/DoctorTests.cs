using Domain.Contracts.DoctorManagement.Events;
using Domain.DoctorManagement;
using Domain.DoctorManagement.Exceptions;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTest.DoctorManagement;

public class DoctorTests
{
    [Fact]
    public void reconstitute_doctor()
    {
        var id = 1;
        var firstName = "behnam";
        var lastName = "seydAbadi";
        var phoneNumber = "09334255888";

        var appointment = Appointment.Reconstitute(
            id: 2, patientId: 3, durationMinutes: 15,
            startDateTime: DateTime.Now, isConfirmed: true);


        var doctor = GeneralPractitioner.Reconstitute(
            id, name: "behnam", lastName: "seydAbadi",
            phoneNumber: "09334255888", new[] { appointment });


        doctor.Id.Should().Be(id);
        doctor.Name.First.Should().Be(firstName);
        doctor.Name.Last.Should().Be(lastName);
        doctor.PhoneNumber.Value.Should().Be(phoneNumber);

        doctor.GetAppointments().Contains(appointment).Should().BeTrue();
    }

    [Fact]
    public void confirm_appointment()
    {
        var appointmentId = 1;

        var appointment = Appointment.Reconstitute(
            appointmentId, patientId: 3, durationMinutes: 15,
            startDateTime: DateTime.Now, isConfirmed: false);

        var doctor = GeneralPractitioner.Reconstitute(
            4, name: "behnam", lastName: "seydAbadi",
            phoneNumber: "09334255888", new[] { appointment });


        doctor.ConfirmAppointment(appointmentId);


        doctor.GetAppointments().Single().IsConfirmed.Should().BeTrue();

        var expectingDomainEvent = new AppointmentConfirmedDomainEvent(doctor.Id, appointmentId);
        doctor.GetQueuedEvents().Contains(expectingDomainEvent).Should().BeTrue();
    }

    [Fact]
    public void confirm_an_already_confirmed_appointment_shouldThrowException()
    {
        var appointmentId = 1;

        var appointment = Appointment.Reconstitute(
            appointmentId, patientId: 3, durationMinutes: 15,
            startDateTime: DateTime.Now, isConfirmed: true);

        var doctor = GeneralPractitioner.Reconstitute(
            4, name: "behnam", lastName: "seydAbadi",
            phoneNumber: "09334255888", new[] { appointment });


        Action action = () => doctor.ConfirmAppointment(appointmentId);


        action.Should().ThrowExactly<AppointmentIsAlreadyConfirmedException>();
    }
}