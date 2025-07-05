using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Queries;
using uTimePlatform.Reservation.Domain.Services;
using uTimePlatform.Reservation.Interfaces.ACL;

namespace uTimePlatform.Reservation.Application.ACL;

public class PaymentContextFacadeAdapter(IPaymentQueryService paymentQueryService) : IPaymentContextFacade
{
    public async Task<Payments?> GetPaymentByIdAsync(int id)
    {
        return await paymentQueryService.Handle(new GetPaymentByIdQuery(id));
    }
}