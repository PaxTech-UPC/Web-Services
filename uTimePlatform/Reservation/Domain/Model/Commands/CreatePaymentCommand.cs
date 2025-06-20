namespace uTimePlatform.Reservation.Domain.Model.Commands;

public record CreatePaymentCommand(
     decimal Amount,
     string Currency,
     bool Status
    );