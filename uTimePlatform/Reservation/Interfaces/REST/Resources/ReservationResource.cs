namespace uTimePlatform.Reservation.Interfaces.REST.Resources;

public record ReservationResource(
    int Id,
    int ClientId,
    int ProviderId,
    int PaymentId,
    int TimeSlotId,
    int WorkerId
);