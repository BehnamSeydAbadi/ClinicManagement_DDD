using Domain.PatientManagement;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTest.PatientManagement;

public class PatientTests
{
    [Fact]
    public void register_new_patient()
    {
        var name = "behnam";
        var lastName = "seydabadi";
        var nationalCode = "0019936162";
        var birthDate = new DateOnly(year: 1997, month: 3, day: 29);
        var phoneNumber = "09334155680";

        var patient = Patient.Register(1, name, lastName, nationalCode, birthDate, phoneNumber);

        patient.Name.First.Should().Be(name);
        patient.Name.Last.Should().Be(lastName);
        patient.NationalCode.Value.Should().Be(nationalCode);
        patient.BirthDate.Value.Should().Be(birthDate);
        patient.PhoneNumber.Value.Should().Be(phoneNumber);
    }

    [Fact]
    public void schedule_an_appointment()
    {
        var patient = Patient.Reconstitute(
            1, name: "behnam", lastName: "seydabadi", nationalCode: "0019936162",
            birthDate: new DateOnly(year: 1997, month: 3, day: 29),
            phoneNumber: "09334155680");

        patient.Schedule(doctorId: 2, durationMinutes: 15, startDateTime: DateTime.Now.AddDays(1));

        patient.GetAppointments().Count().Should().Be(1);
    }
}
