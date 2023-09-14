using Domain.PatientManagement;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        var dbEntity = await _dbContext.Patients.FindAsync(request.PatientId);

        //TODO: Validate it's existence

        var patient = Patient.Reconstitute(
            dbEntity.Id, dbEntity.Name, dbEntity.LastName, dbEntity.NationalCode,
            DateOnly.FromDateTime(dbEntity.BirthDate), dbEntity.PhoneNumber);

        var lastAppointment = await _dbContext.Appointments.OrderByDescending(a => a.Id).LastOrDefaultAsync();

        var appointmentId = (lastAppointment?.Id + 1) ?? 1;

        patient.ScheduleAppointment(appointmentId, request.DoctorId, request.DurationMinutes, request.StartDateTime);

        return appointmentId;
    }
}
