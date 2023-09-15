using Application.Common;
using Domain.PatientManagement;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PatientManagement.Appointment.Commands;

internal class ScheduleCommandHandler : CommandHandler<ScheduleCommand, int>
{
    private readonly AppDbContext _dbContext;

    public ScheduleCommandHandler(AppDbContext dbContext, IMediator mediator) : base(mediator) => _dbContext = dbContext;

    public override async Task<int> Handle(ScheduleCommand request, CancellationToken cancellationToken)
    {
        var dbEntity = await _dbContext.Patients.FindAsync(request.PatientId);

        //TODO: Validate it's existence

        var patient = Patient.Reconstitute(
            dbEntity.Id, dbEntity.Name, dbEntity.LastName, dbEntity.NationalCode,
            DateOnly.FromDateTime(dbEntity.BirthDate), dbEntity.PhoneNumber);

        var appointmentId = GenerateId();

        patient.ScheduleAppointment(appointmentId, request.DoctorId, request.DurationMinutes, request.StartDateTime);

        await PublishAsync(patient.GetQueuedEvents());

        return appointmentId;
    }
}
