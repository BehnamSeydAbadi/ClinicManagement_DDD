namespace AcceptanceTest.PatientDoctorInteraction;

public record AppointmentDto
{
    public int DoctorId { get; init; }
    public int PatientId { get; init; }
    public int DurationMinutes { get; init; }
    public TimeOnly StartDateTime { get; init; }
}