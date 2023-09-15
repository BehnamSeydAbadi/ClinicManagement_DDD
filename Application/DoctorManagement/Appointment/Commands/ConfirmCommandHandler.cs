using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DoctorManagement.Appointment.Commands;

internal class ConfirmCommandHandler : IRequestHandler<ConfirmCommand>
{
    private readonly AppDbContext _dbContext;

    public ConfirmCommandHandler(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(ConfirmCommand request, CancellationToken cancellationToken)
    {
        var dbEntity = await _dbContext.Appointments
            .Include(a => a.Doctor).SingleOrDefaultAsync(a => a.Id == request.Id);

        //TODO: Should write validations for appointment existence

        //TODO: Reconstitute the doctor

        return Unit.Value;
    }
}
