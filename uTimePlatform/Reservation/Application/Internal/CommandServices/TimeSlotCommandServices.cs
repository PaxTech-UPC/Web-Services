using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Model.Commands;
using uTimePlatform.Reservation.Domain.Repositories;
using uTimePlatform.Reservation.Domain.Services;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Reservation.Application.Internal.CommandServices;

public class TimeSlotCommandServices (ITimeSlotRepository timeSlotRepository, IUnitOfWork unitOfWork)
    : ITimeSlotCommandService
{
    public async Task<TimeSlots?> Handle(CreateTimeSlotCommand command)
    {
        var timeSlots = new TimeSlots();
        try
        {
            await timeSlotRepository.AddAsync(timeSlots);
            await unitOfWork.CompleteAsync();
            return timeSlots;
        }
        catch (Exception)
        {
            return null;
        }
    }
}