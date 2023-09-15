using Common.Exception;

namespace Domain.DoctorManagement.Exceptions;

public class AppointmentIsAlreadyConfirmedException : Exception, IException
{
    public static AppointmentIsAlreadyConfirmedException Throw()
    {
        throw new AppointmentIsAlreadyConfirmedException();
    }

    private AppointmentIsAlreadyConfirmedException() : base("Appointment is already confirmed")
    {
    }
}
