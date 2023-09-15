using Application.DoctorManagement.Appointment.Commands;
using Application.PatientManagement.Appointment.Commands;
using Application.PatientManagement.Appointment.Queries;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Appointment;

public class AppointmentController : BaseApiController
{
    private readonly ISender _mediator;
    private readonly AppDbContext appDbContext;
    public AppointmentController(ISender mediator, AppDbContext appDbContext)
    {
        _mediator = mediator;
        this.appDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ScheduleCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var viewModel = await _mediator.Send(new GetByIdQuery(id));
        return Ok(viewModel);
    }

    [HttpPatch("{id}/confirm")]
    public async Task<IActionResult> Confirm(int id)
    {
        await _mediator.Send(new ConfirmCommand(id));
        return Ok();
    }
}
