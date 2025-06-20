using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Domain.Model.Queries;
using uTimePlatform.Reservation.Domain.Model.Aggregates;

namespace uTimePlatform.Reservation.Domain.Services;

public interface IReservationCommandService
{
    Task<Model.Aggregates.Reservation?> Handle(CreateReservationCommand command);
}