namespace uTimePlatform.Reservation.Interfaces.REST.Resources;

public record CreateReservationResource(
        int SalonId,
        int ClientId,
        int PaymentId,
        int TimeSlotId,
        int WorkerId
    );