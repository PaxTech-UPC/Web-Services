using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.IAM.Domain.Repositories;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using uTimePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace uTimePlatform.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(e => e.Email.Equals(email));
    }


    public bool ExistsByEmail(string email)
    {
        return Context.Set<User>().Any(e => e.Email.Equals(email));
    }
}