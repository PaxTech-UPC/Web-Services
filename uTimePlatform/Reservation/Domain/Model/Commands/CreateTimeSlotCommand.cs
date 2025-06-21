namespace uTimePlatform.Reservation.Domain.Model.Commands;

public record CreateTimeSlotCommand(
    DateTime startTime,
    DateTime endTime,
    bool status,
    string type
);
