using uTimePlatform.Reservation.Domain.Model.ValueObjects;

namespace uTimePlatform.Reservation.Interfaces.REST.Resources;

public record CreatePaymentResource(
        decimal Amount,
        string Currency,
        bool Status
    );