using Domain.DoctorManagement;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DoctorAppointment = Domain.DoctorManagement.Appointment;

namespace Application.DoctorManagement.Appointment.Commands;

internal class ConfirmCommandHandler : IRequestHandler<ConfirmCommand>
{
    private readonly AppDbContext _dbContext;
    private readonly IMediator _mediator;

    public ConfirmCommandHandler(AppDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(ConfirmCommand request, CancellationToken cancellationToken)
    {
        var appointmentDbEntity = await _dbContext.Appointments
            .Include(a => a.Doctor).SingleOrDefaultAsync(a => a.Id == request.Id);

        //TODO: Should write validations for appointment existence

        var doctorDbEntity = appointmentDbEntity.Doctor;

        var appointment = DoctorAppointment.Reconstitute(
            appointmentDbEntity.Id, appointmentDbEntity.PatientId,
            appointmentDbEntity.DurationMinutes, appointmentDbEntity.StartDateTime,
            appointmentDbEntity.IsConfirmed);

        var doctor = Doctor.Reconstitute(
            doctorDbEntity.Id, doctorDbEntity.Name, doctorDbEntity.LastName,
            doctorDbEntity.PhoneNumber, new[] { appointment });

        doctor.ConfirmAppointment(request.Id);

        foreach (var @event in doctor.GetQueuedEvents())
            await _mediator.Publish(@event);

        return Unit.Value;
    }
}
