using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Interfaces.REST.Resources;

namespace uTimePlatform.Reservation.Interfaces.REST.Transform;

public static class CreateReservationCommandFromResourceAssembler
{
    public static CreateReservationCommand ToCommandFromResource(CreateReservationResource resource) =>
        new CreateReservationCommand(
                resource.SalonId,
                resource.ClientId,
                resource.PaymentId,
                resource.TimeSlotId, 
                resource.WorkerId
            );
}