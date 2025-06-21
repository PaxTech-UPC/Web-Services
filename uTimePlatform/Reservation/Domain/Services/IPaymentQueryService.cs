using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Queries;

namespace uTimePlatform.Reservation.Domain.Services;

public interface IPaymentQueryService
{
    Task<Payments?> Handle(GetPaymentByIdQuery  query);
    Task<IEnumerable<Payments>?> Handle (GetAllPaymentsQuery query);
}