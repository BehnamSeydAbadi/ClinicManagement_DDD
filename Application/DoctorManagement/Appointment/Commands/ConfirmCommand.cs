using MediatR;

namespace Application.DoctorManagement.Appointment.Commands;

public class ConfirmCommand : IRequest
{
    public int Id { get; }

    public ConfirmCommand(int id) => Id = id;
}
