using Domain.Contracts.PatientManagement;
using Infrastructure.Appointment;
using MediatR;

namespace Infrastructure.Patient.DomainEventHandler;

internal class AppointmentScheduledDomainEventHandler : INotificationHandler<AppointmentScheduledDomainEvent>
{
    private readonly AppDbContext _dbContext;

    public AppointmentScheduledDomainEventHandler(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(AppointmentScheduledDomainEvent notification, CancellationToken cancellationToken)
    {
        _dbContext.Appointments.Add(new AppointmentDbEntity
        {
            Id = notification.Id,
            PatientId = notification.AggregateId,
            DoctorId = notification.DoctorId,
            DurationMinutes = notification.DurationMinutes,
            StartDateTime = notification.StartDateTime,
        });

        await _dbContext.SaveChangesAsync();
    }
}
