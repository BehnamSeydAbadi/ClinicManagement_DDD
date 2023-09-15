namespace Application.PatientManagement.Appointment.Queries.ViewModels;

public sealed record AppointmentViewModel
{
    public int Id { get; init; }
    public int PatientId { get; init; }
    public string PatientFullName { get; init; }
    public int DoctorId { get; init; }
    public string DoctorFullName { get; init; }
    public int DurationMinutes { get; init; }
    public string StartDateTime { get; init; }
    public bool IsConfirmed { get; init; }
}
