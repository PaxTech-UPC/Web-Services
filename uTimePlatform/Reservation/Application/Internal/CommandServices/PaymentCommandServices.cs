using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Domain.Repositories;
using uTimePlatform.Reservation.Domain.Services;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Reservation.Application.Internal.CommandServices;

public class PaymentCommandServices(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    : IPaymentCommandService
{
    public async Task<Payments?> Handle(CreatePaymentCommand command)
    {
        var payment = new Payments(command);

        try
        {
            await paymentRepository.AddAsync(payment);
            await unitOfWork.CompleteAsync();
            return payment;
        }
        catch (Exception)
        {
            return null;
        }

    }
}
