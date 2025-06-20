using uTimePlatform.Reservation.Domain.Model.Aggregates;

namespace uTimePlatform.Reservation.Interfaces.ACL;

public interface IPaymentContextFacade
{
    Task<Payments?> GetPaymentByIdAsync(int id);
}   