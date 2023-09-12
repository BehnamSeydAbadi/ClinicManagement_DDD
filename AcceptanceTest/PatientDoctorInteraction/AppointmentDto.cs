namespace AcceptanceTest.PatientDoctorInteraction;

public record AppointmentDto
{
    public string DoctorId { get; init; }
    public string PatientId { get; init; }
    public string DurationMinutes { get; init; }
    public string StartDateTime { get; init; }
}