using Application.PatientManagement.Appointment.Queries.ViewModels;
using MediatR;

namespace Application.PatientManagement.Appointment.Queries;

public class GetByIdQuery : IRequest<AppointmentViewModel>
{
    public int Id { get; }

    public GetByIdQuery(int id) => Id = id;
}
