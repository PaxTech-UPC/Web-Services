using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Interfaces.REST.Resources;

namespace uTimePlatform.Reservation.Interfaces.REST.Transform;

public static class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payments payment) =>
        new PaymentResource(
            payment.Id,
            payment.Money.Amount,
            payment.Money.Currency,
            payment.Status
        );
}