using MediatR;

namespace Application.Appointment.Commands;

internal class ScheduleCommandHandler : IRequestHandler<ScheduleCommand, int>
{
    public async Task<int> Handle(ScheduleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
