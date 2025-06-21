using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.IAM.Interfaces.REST.Resources;

namespace uTimePlatform.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Email);
    }
}