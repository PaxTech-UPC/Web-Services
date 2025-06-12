using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.IAM.Domain.Model.Commands;

namespace uTimePlatform.IAM.Domain.Services;

public interface IUserCommandService
{

    Task<(User user, string token)> Handle(SignInCommand command);


    Task Handle(SignUpCommand command);
}