using Microsoft.EntityFrameworkCore;
using uTimePlatform.Reservation.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace uTimePlatform.Reservation.Infrastructure.Persistence.EFC.Repositories
{
    public class ReservationRepository : BaseRepository<Domain.Model.Aggregates.Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context) {}

        public async Task<List<Domain.Model.Aggregates.Reservation>> FindAllAsync()
        {
            return await Context.Set<Domain.Model.Aggregates.Reservation>().ToListAsync();
        }
    }
}
