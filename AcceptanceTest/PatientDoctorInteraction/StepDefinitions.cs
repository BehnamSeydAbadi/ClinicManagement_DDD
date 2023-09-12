using TechTalk.SpecFlow;

namespace AcceptanceTest.PatientDoctorInteraction;

[Binding]
[Scope(Feature = "Patient doctor interaction")]
public class StepDefinitions
{
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
    public void WhenIProvideMyNameContactInformationAndPreferredDateAndTime()
    {
        throw new PendingStepException();
    }

    [Then(@"the doctor should confirm the appointment")]
    public void ThenTheDoctorShouldConfirmTheAppointment()
    {
        throw new PendingStepException();
    }
}
