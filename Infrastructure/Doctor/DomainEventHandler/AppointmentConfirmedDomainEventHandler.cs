using Domain.Contracts.DoctorManagement;
using MediatR;

namespace Infrastructure.Doctor.DomainEventHandler;

internal class AppointmentConfirmedDomainEventHandler : INotificationHandler<AppointmentConfirmedDomainEvent>
{
    private readonly AppDbContext _dbContext;

    public AppointmentConfirmedDomainEventHandler(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(AppointmentConfirmedDomainEvent notification, CancellationToken cancellationToken)
    {
        var dbEntity = await _dbContext.Appointments.FindAsync(notification.Id);

        dbEntity.IsConfirmed = true;

        _dbContext.Appointments.Update(dbEntity);

        await _dbContext.SaveChangesAsync();
    }
}
