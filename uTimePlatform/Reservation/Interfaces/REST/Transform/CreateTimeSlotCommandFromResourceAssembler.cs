using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Interfaces.REST.Resources;

namespace uTimePlatform.Reservation.Interfaces.REST.Transform;

public class CreateTimeSlotCommandFromResourceAssembler
{
    public static CreateTimeSlotCommand ToCommandFromResource(CreateTimeSlotResource resource) =>
        new CreateTimeSlotCommand(
                resource.StartTime,
                resource.EndTime,
                resource.Status,
                resource.Type
            );
}