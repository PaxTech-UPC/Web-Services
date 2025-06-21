using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Queries;
using uTimePlatform.Reservation.Domain.Repositories;
using uTimePlatform.Reservation.Domain.Services;
using uTimePlatform.Reservation.Infrastructure.Persistence.EFC.Repositories;

namespace uTimePlatform.Reservation.Application.Internal.QueryServices;

public class TimeSlotQueryServices(ITimeSlotRepository timeSlotRepository) : ITimeSlotQueryService
{
    public async Task<IEnumerable<TimeSlots>?> Handle(GetAllTimeSlotsQuery query)
    {
        return await timeSlotRepository.FindAllAsync();
    }

    public async Task<TimeSlots?> Handle(GetTimeSlotByIdQuery query)
    {
        return await timeSlotRepository.FindByIdAsync(query.Id);
    }
}