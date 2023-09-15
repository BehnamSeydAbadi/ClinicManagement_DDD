using Application.PatientManagement.Appointment.Queries.ViewModels;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PatientManagement.Appointment.Queries;

internal class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, AppointmentViewModel>
{
    private readonly AppDbContext _dbContext;

    public GetByIdQueryHandler(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<AppointmentViewModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Appointments
            .Include(a => a.Doctor).Include(a => a.Patient)
            .SingleOrDefaultAsync(a => a.Id == request.Id);

        if (entity is null) return null;

        return new AppointmentViewModel
        {
            Id = entity.Id,
            PatientId = entity.PatientId,
            DoctorId = entity.DoctorId,
            PatientFullName = $"{entity.Patient.Name} {entity.Patient.LastName}",
            DoctorFullName = $"{entity.Doctor.Name} {entity.Doctor.LastName}",
            DurationMinutes = entity.DurationMinutes,
            StartDateTime = entity.StartDateTime.ToString("yyyy-MM-dd hh:mm:ss tt"),
            IsConfirmed = entity.IsConfirmed
        };
    }
}
