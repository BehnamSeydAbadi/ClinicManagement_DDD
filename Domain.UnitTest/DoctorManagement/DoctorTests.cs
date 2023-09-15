using Domain.DoctorManagement;
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

        var doctor = Doctor.Reconstitute(id, "behnam", "seydAbadi", "09334255888");

        doctor.Id.Should().Be(id);
        doctor.Name.First.Should().Be(firstName);
        doctor.Name.Last.Should().Be(lastName);
        doctor.PhoneNumber.Value.Should().Be(phoneNumber);
    }

    [Fact]
    public void confirm_appointment()
    {
        //var doctor = Doctor.Reconstitute(2, "behnam", "seydAbadi", "09334255888");

        //var appointmentId = 1;

        //doctor.ConfirmAppointment(appointmentId);

        //doctor.GetAppointments().Single().IsConfirmed.Should().BeTrue();
    }
}
