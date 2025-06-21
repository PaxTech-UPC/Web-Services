namespace uTimePlatform.Reservation.Interfaces.REST.Resources;

public record TimeSlotResource(
    int Id,
    DateTime StartTime,
    DateTime EndTime,
    bool Status,
    string Type
);