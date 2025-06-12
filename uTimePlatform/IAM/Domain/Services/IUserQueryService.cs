using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.IAM.Domain.Model.Queries;

namespace uTimePlatform.IAM.Domain.Services;

public interface IUserQueryService
{
    
    Task<User?> Handle(GetUserByIdQuery query);

    
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    
    
    Task<User?> Handle(GetUserByEmailQuery query);
}