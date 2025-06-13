using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.IAM.Interfaces.REST.Resources;

namespace uTimePlatform.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Email, token);
    }
}