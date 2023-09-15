using MediatR;

namespace Application.PatientManagement.Appointment.Commands;

public class ScheduleCommand : IRequest<int>
{
    public int DoctorId { get; init; }
    public int PatientId { get; init; }
    public int DurationMinutes { get; init; }
    public DateTime StartDateTime { get; init; }
}
