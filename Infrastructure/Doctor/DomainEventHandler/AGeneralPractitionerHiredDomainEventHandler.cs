using Domain.Contracts.DoctorManagement.Enums;
using Domain.Contracts.DoctorManagement.Events;
using MediatR;

namespace Infrastructure.Doctor.DomainEventHandler;

internal class AGeneralPractitionerHiredDomainEventHandler : INotificationHandler<AGeneralPractitionerHiredDomainEvent>
{
    private readonly AppDbContext _dbContext;

    public AGeneralPractitionerHiredDomainEventHandler(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(AGeneralPractitionerHiredDomainEvent notification, CancellationToken cancellationToken)
    {
        var dbEntity = new DoctorDbEntity
        {
            Id = notification.AggregateId,
            Name = notification.Name,
            LastName = notification.LastName,
            PhoneNumber = notification.PhoneNumber,
            Type = DoctorType.GeneralPractitioner
        };

        _dbContext.Doctors.Add(dbEntity);

        await _dbContext.SaveChangesAsync();
    }
}
