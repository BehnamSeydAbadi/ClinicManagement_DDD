using Infrastructure;
using MediatR;

namespace Application.Appointment.Commands;

internal class ScheduleCommandHandler : IRequestHandler<ScheduleCommand, int>
{
    private readonly AppDbContext _dbContext;
    public ScheduleCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(ScheduleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
