using uTimePlatform.Reservation.Interfaces.REST.Resources;

namespace uTimePlatform.Reservation.Interfaces.REST.Transform;

public static class ReservationResourceFromEntityAssembler
{
    public static ReservationResource ToResourceFromEntity(Domain.Model.Aggregates.Reservation reservation)
    {
        return new ReservationResource(
            reservation.Id,
            reservation.SalonId,
            reservation.ClientId,
            reservation.PaymentId,
            reservation.TimeSlotId,
            reservation.WorkerId
        );
    }
}
