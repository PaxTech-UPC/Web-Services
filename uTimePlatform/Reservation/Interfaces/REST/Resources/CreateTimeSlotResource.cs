namespace uTimePlatform.Reservation.Interfaces.REST.Resources;

public record CreateTimeSlotResource(
        DateTime StartTime,
        DateTime EndTime,
        bool Status,
        string Type
    );