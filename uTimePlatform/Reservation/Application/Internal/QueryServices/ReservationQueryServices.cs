using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Queries;
using uTimePlatform.Reservation.Domain.Repositories;
using uTimePlatform.Reservation.Domain.Services;

namespace uTimePlatform.Reservation.Application.Internal.QueryServices;

public class ReservationQueryServices(IReservationRepository reservationRepository) 
    : IReservationQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Reservation>?> Handle(GetAllReservationsQuery query)
    {
        return await reservationRepository.FindAllAsync();
    }
    
    public async Task<Domain.Model.Aggregates.Reservation?> Handle(GetReservationByIdQuery query)
    {
        return await reservationRepository.FindByIdAsync(query.Id);
    }
}
