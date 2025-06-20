using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Queries;
using uTimePlatform.Reservation.Domain.Repositories;
using uTimePlatform.Reservation.Domain.Services;

namespace uTimePlatform.Reservation.Application.Internal.QueryServices;

public class PaymentQueryServices(IPaymentRepository paymentRepository)
    : IPaymentQueryService
{
    public async Task<IEnumerable<Payments>?> Handle(GetAllPaymentsQuery query)
    {
        return await paymentRepository.FindAllAsync();
    }
    
    public async Task<Payments?> Handle(GetPaymentByIdQuery query)
    {
        return await paymentRepository.FindByIdAsync(query.Id);
    }
}