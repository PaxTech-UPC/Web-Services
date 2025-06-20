using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Interfaces.REST.Resources;

namespace uTimePlatform.Reservation.Interfaces.REST.Transform;

public class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource) =>
        new CreatePaymentCommand(
                resource.Amount,
                resource.Currency,
                resource.Status
            );
}