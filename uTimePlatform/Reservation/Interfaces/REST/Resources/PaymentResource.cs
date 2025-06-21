namespace uTimePlatform.Reservation.Interfaces.REST.Resources;

public record PaymentResource(
        int Id,
        decimal Amount,
        string Currency,
        bool Status
    );