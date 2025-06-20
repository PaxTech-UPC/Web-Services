using uTimePlatform.Reservation.Domain.Model.Queries;

namespace uTimePlatform.Reservation.Domain.Services;

public interface IReservationQueryService
{
    Task<Model.Aggregates.Reservation?> Handle(GetReservationByIdQuery  query);
    Task<IEnumerable<Model.Aggregates.Reservation>?> Handle (GetAllReservationsQuery query);
}