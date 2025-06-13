using uTimePlatform.IAM.Domain.Model.Commands;
using uTimePlatform.IAM.Interfaces.REST.Resources;

namespace uTimePlatform.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password);
    }
}