using Domain.Contracts.Patient;
using MediatR;

namespace Infrastructure.Patient.Projectors;

internal class PatientRegisteredDomainEventHandler : INotificationHandler<PatientRegisteredDomainEvent>
{
    private readonly AppDbContext _dbContext;

    public PatientRegisteredDomainEventHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(PatientRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        _dbContext.Patients.Add(new PatientDbEntity
        {
            Name = notification.Name,
            LastName = notification.LastName,
            NationalCode = notification.NationalCode,
            BirthDate = notification.BirthDate.ToDateTime(TimeOnly.MinValue),
            PhoneNumber = notification.PhoneNumber,
        });

        await _dbContext.SaveChangesAsync();
    }
}
