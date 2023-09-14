using Application.Appointment.Queries.ViewModels;
using Bogus;
using FluentAssertions;
using Infrastructure;
using Infrastructure.Doctor;
using Infrastructure.Patient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace AcceptanceTest.PatientDoctorInteraction;

[Binding]
[Scope(Feature = "Patient doctor interaction")]
public class StepDefinitions
{
    private readonly HttpClient _httpClient;
    private readonly AppDbContext _dbContext;

    public StepDefinitions(HttpClient httpClient, AppDbContext dbContext)
    {
        _httpClient = httpClient;
        _dbContext = dbContext;
    }

    [Given(@"I am a patient")]
    public async Task GivenIAmAPatient()
    {
        var patient = new Faker<PatientDbEntity>()
            .Ignore(p => p.Id)
            .RuleFor(p => p.Name, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.NationalCode, f => string.Join("", f.Random.Digits(10)))
            .RuleFor(p => p.BirthDate, f => f.Person.DateOfBirth.Date)
            .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber())
            .Generate();

        _dbContext.Patients.Add(patient);

        await _dbContext.SaveChangesAsync();
    }

    [Given(@"I want to schedule an appointment with a doctor")]
    public async void GivenIWantToScheduleAnAppointmentWithADoctor()
    {
        var doctor = new Faker<DoctorDbEntity>()
            .RuleFor(p => p.Name, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber())
            .Generate();

        _dbContext.Doctors.Add(doctor);

        await _dbContext.SaveChangesAsync();
    }

    [When(@"I provide my name, contact information, and preferred date and time")]
    public async Task WhenIProvideMyNameContactInformationAndPreferredDateAndTime()
    {
        var apiContent = ConvertToStringContent(new AppointmentDto
        {
            DoctorId = "",
            PatientId = "",
            DurationMinutes = "",
            StartDateTime = ""
        });

        var apiResult = await _httpClient.PostAsync("api/appointment", apiContent);
        apiResult.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Then(@"the doctor should confirm the appointment")]
    public async Task ThenTheDoctorShouldConfirmTheAppointment()
    {
        var appointment = await _dbContext.Appointments.SingleAsync();

        var apiResult = await _httpClient.GetAsync($"api/appointment/{appointment.Id}");
        apiResult.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await apiResult.Content.ReadAsStringAsync();
        var viewModel = JsonConvert.DeserializeObject<AppointmentViewModel>(content)!;

        viewModel.IsConfirmed.Should().BeTrue();
    }


    private static StringContent ConvertToStringContent<T>(T content)
    {
        var json = JsonConvert.SerializeObject(content);

        return new(json, Encoding.UTF8, "application/json");
    }
}
