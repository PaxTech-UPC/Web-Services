namespace uTimePlatform.Reservation.Domain.Model.Commands;

public record CreateReservationCommand(
        int SalonId,
        int ClientId,
        int PaymentId,
        int TimeSlotId,
        int WorkerId
    );