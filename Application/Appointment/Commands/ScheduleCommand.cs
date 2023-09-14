﻿using MediatR;

namespace Application.Appointment.Commands;

public class ScheduleCommand : IRequest<int>
{
    public int DoctorId { get; init; }
    public int PatientId { get; init; }
    public int DurationMinutes { get; init; }
    public TimeOnly StartDateTime { get; init; }
}