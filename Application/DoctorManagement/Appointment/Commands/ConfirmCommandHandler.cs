using Application.Common;
using Domain.DoctorManagement;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DoctorAppointment = Domain.DoctorManagement.Appointment;

namespace Application.DoctorManagement.Appointment.Commands;

internal class ConfirmCommandHandler : CommandHandler<ConfirmCommand, Unit>
{
    private readonly AppDbContext _dbContext;

    public ConfirmCommandHandler(AppDbContext dbContext, IMediator mediator) : base(mediator) => _dbContext = dbContext;

    public override async Task<Unit> Handle(ConfirmCommand request, CancellationToken cancellationToken)
    {
        var appointmentDbEntity = await _dbContext.Appointments
            .Include(a => a.Doctor).SingleOrDefaultAsync(a => a.Id == request.Id);

        //TODO: Should write validations for appointment existence

        var doctorDbEntity = appointmentDbEntity.Doctor;

        var appointment = DoctorAppointment.Reconstitute(
            appointmentDbEntity.Id, appointmentDbEntity.PatientId,
            appointmentDbEntity.DurationMinutes, appointmentDbEntity.StartDateTime,
            appointmentDbEntity.IsConfirmed);

        var doctor = GeneralPractitioner.Reconstitute(
            doctorDbEntity.Id, doctorDbEntity.Name, doctorDbEntity.LastName,
            doctorDbEntity.PhoneNumber, new[] { appointment });

        doctor.ConfirmAppointment(request.Id);

        await PublishAsync(doctor.GetQueuedEvents());

        return Unit.Value;
    }
}
