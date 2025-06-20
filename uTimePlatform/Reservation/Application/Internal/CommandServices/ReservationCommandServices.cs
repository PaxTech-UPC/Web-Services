using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Domain.Repositories;
using uTimePlatform.Reservation.Domain.Services;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Reservation.Application.Internal.CommandServices;

public class ReservationCommandServices (IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
    : IReservationCommandService
{
    public async Task<Domain.Model.Aggregates.Reservation?> Handle(CreateReservationCommand command)
    {
        var reservation = new Domain.Model.Aggregates.Reservation(command);
        try
        {
            await reservationRepository.AddAsync(reservation);
            await unitOfWork.CompleteAsync();
            return reservation;
        }
        catch (Exception)
        {
            return null;
        }
    }
}