using Application.Appointment.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Appointment;

public class AppointmentController : BaseApiController
{
    private readonly ISender _mediator;

    public AppointmentController(ISender mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ScheduleCommand command)
    {

        var id = await _mediator.Send(command);
        return Ok(id);
    }
}
