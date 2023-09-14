using MediatR;

namespace Application.Appointment.Commands;

internal class ScheduleAppointmentCommandHandler : IRequestHandler<ScheduleAppointmentCommand, int>
{
    public async Task<int> Handle(ScheduleAppointmentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
