using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{

    Task<User?> FindByEmailAsync(string email);


    bool ExistsByEmail(string email);
}