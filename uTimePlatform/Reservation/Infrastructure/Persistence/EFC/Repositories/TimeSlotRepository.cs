using Microsoft.EntityFrameworkCore;
using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace uTimePlatform.Reservation.Infrastructure.Persistence.EFC.Repositories
{
    public class TimeSlotRepository : BaseRepository<TimeSlots>, ITimeSlotRepository
    {
        public TimeSlotRepository(AppDbContext context) : base(context) {}

        public async Task<List<TimeSlots>> FindAllAsync()
        {
            return await Context.Set<TimeSlots>().ToListAsync();
        }
    }
}

