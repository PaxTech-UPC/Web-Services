using Microsoft.EntityFrameworkCore;
using uTimePlatform.Reservation.Domain.Model.Aggregates;
using uTimePlatform.Reservation.Domain.Repositories;
using uTimePlatform.Shared.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace uTimePlatform.Reservation.Infrastructure.Persistence.EFC.Repositories
{
    public class PaymentRepository : BaseRepository<Payments>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) :  base(context) {}

        public async Task<List<Payments>> FindAllAsync()
        {
            return await Context.Set<Payments>().ToListAsync();
        }
    }
}

