using Newtonsoft.Json;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace AcceptanceTest.PatientDoctorInteraction;

[Binding]
[Scope(Feature = "Patient doctor interaction")]
public class StepDefinitions
{
    private readonly HttpClient _httpClient;

    public StepDefinitions(HttpClient httpClient) => _httpClient = httpClient;


    [Given(@"I am a patient")]
    public void GivenIAmAPatient()
    {
        throw new PendingStepException();
    }

    [Given(@"I want to schedule an appointment with a doctor")]
    public void GivenIWantToScheduleAnAppointmentWithADoctor()
    {
        throw new PendingStepException();
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
    }

    [Then(@"the doctor should confirm the appointment")]
    public void ThenTheDoctorShouldConfirmTheAppointment()
    {
        throw new PendingStepException();
    }


    private static StringContent ConvertToStringContent<T>(T content)
    {
        var json = JsonConvert.SerializeObject(content);

        return new(json, Encoding.UTF8, "application/json");
    }
}
