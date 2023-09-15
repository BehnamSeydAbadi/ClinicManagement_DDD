using Domain.Contracts.PatientManagement;
using Infrastructure.Patient.DomainEventHandler;
using Infrastructure.Patient.Projectors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations
{
    public static class ServiceResolver
    {
        public static void ResolveInfrastructureServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            serviceCollection.AddScoped<INotificationHandler<PatientRegisteredDomainEvent>, PatientRegisteredDomainEventHandler>();
            serviceCollection.AddScoped<INotificationHandler<AppointmentScheduledDomainEvent>, AppointmentScheduledDomainEventHandler>();
        }
    }
}
