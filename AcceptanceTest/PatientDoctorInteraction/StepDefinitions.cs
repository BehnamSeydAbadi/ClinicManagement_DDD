using Application.PatientManagement.Appointment.Commands;
using Application.PatientManagement.Appointment.Queries.ViewModels;
using Bogus;
using Domain.Contracts.DoctorManagement.Enums;
using FluentAssertions;
using Infrastructure;
using Infrastructure.Appointment;
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
    private readonly ScenarioContext _scenarioContext;

    public StepDefinitions(ScenarioContext scenarioContext, HttpClient httpClient, AppDbContext dbContext)
    {
        _scenarioContext = scenarioContext;
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
    public async Task GivenIWantToScheduleAnAppointmentWithADoctor()
    {
        var doctor = new Faker<DoctorDbEntity>()
            .RuleFor(p => p.Name, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber(format: "###-###-####"))
            .Generate();

        _dbContext.Doctors.Add(doctor);

        await _dbContext.SaveChangesAsync();
    }

    [Given(@"I am a doctor")]
    public async Task GivenIAmADoctor()
    {
        var doctor = new Faker<DoctorDbEntity>()
            .Ignore(d => d.Id)
            .RuleFor(d => d.Name, f => f.Name.FirstName())
            .RuleFor(d => d.LastName, f => f.Name.LastName())
            .RuleFor(d => d.PhoneNumber, f => f.Phone.PhoneNumber())
            .Generate();

        _dbContext.Doctors.Add(doctor);

        await _dbContext.SaveChangesAsync();
    }

    [Given(@"I have received an appointment request from a patient")]
    public async Task GivenIHaveReceivedAnAppointmentRequestFromAPatient()
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


        var doctor = await _dbContext.Doctors.SingleAsync();


        var appointment = new AppointmentDbEntity
        {
            Patient = patient,
            Doctor = doctor,
            DurationMinutes = 15,
            StartDateTime = DateTime.Now
        };

        _dbContext.Appointments.Add(appointment);

        await _dbContext.SaveChangesAsync();
    }

    [Given(@"I want to schedule an appointment with a general practitioner")]
    public async Task GivenIWantToScheduleAnAppointmentWithAGeneralPractitioner()
    {
        var doctor = new Faker<DoctorDbEntity>()
             .Ignore(d => d.Id)
             .RuleFor(d => d.Name, f => f.Name.FirstName())
             .RuleFor(d => d.LastName, f => f.Name.LastName())
             .RuleFor(d => d.PhoneNumber, f => f.Phone.PhoneNumber())
             .RuleFor(d => d.Type, DoctorType.GeneralPractitioner)
             .Generate();

        _dbContext.Doctors.Add(doctor);

        await _dbContext.SaveChangesAsync();
    }



    [When(@"I provide my name, contact information, and preferred date and time")]
    public async Task WhenIProvideMyNameContactInformationAndPreferredDateAndTime()
    {
        var doctorId = (await _dbContext.Doctors.SingleAsync()).Id;
        var patientId = (await _dbContext.Patients.SingleAsync()).Id;

        var apiContent = ConvertToStringContent(new ScheduleCommand
        {
            DoctorId = doctorId,
            PatientId = patientId,
            DurationMinutes = 15,
            StartDateTime = DateTime.Now
        });

        var apiResult = await _httpClient.PostAsync("api/appointment", apiContent);
        apiResult.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [When(@"I confirm the appointment with the patient")]
    public async Task WhenIConfirmTheAppointmentWithThePatient()
    {
        var appointmentId = (await _dbContext.Appointments.SingleAsync()).Id;

        var apiResult = await _httpClient.PatchAsync($"api/appointment/{appointmentId}/confirm", null);
        apiResult.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [When(@"I schedule an appointment for (.*) minutes")]
    public async Task WhenIScheduleAnAppointmentForMinutes(int durationMinutes)
    {
        var doctorId = (await _dbContext.Doctors.SingleAsync()).Id;
        var patientId = (await _dbContext.Patients.SingleAsync()).Id;

        var apiContent = ConvertToStringContent(new ScheduleCommand
        {
            DoctorId = doctorId,
            PatientId = patientId,
            DurationMinutes = durationMinutes,
            StartDateTime = DateTime.Now
        });

        var apiResult = await _httpClient.PostAsync("api/appointment", apiContent);

        if (apiResult.IsSuccessStatusCode) return;

        _scenarioContext.Add("error", apiResult.ToOutput().Error.Title);
    }



    [Then(@"the appointment should be scheduled")]
    public async Task ThenTheAppointmentShouldBeScheduled()
    {
        var appointment = await _dbContext.Appointments.SingleAsync();
        appointment.Should().NotBeNull();
    }

    [Then(@"I see the appointment as confirmed")]
    public async Task ThenISeeTheAppointmentAsConfirmed()
    {
        var appointmentId = (await _dbContext.Appointments.SingleAsync()).Id;

        var apiResult = await _httpClient.GetAsync($"api/appointment/{appointmentId}");
        var appointment = apiResult.To<AppointmentViewModel>();

        appointment.Should().NotBeNull();
        appointment.IsConfirmed.Should().BeTrue();
    }

    [Then(@"I should see '([^']*)' as the error message")]
    public void ThenIShouldSeeAsTheErrorMessage(string errorMessage)
    {
        _scenarioContext["error"].ToString().Should().Be(errorMessage);
    }




    private static StringContent ConvertToStringContent<T>(T content)
    {
        var json = JsonConvert.SerializeObject(content);

        return new(json, Encoding.UTF8, "application/json");
    }
}
