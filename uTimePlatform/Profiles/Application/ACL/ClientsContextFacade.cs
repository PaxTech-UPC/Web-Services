using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Services;
using uTimePlatform.Profiles.Interfaces.ACL;

namespace uTimePlatform.Profiles.Application.ACL;

public class ClientsContextFacade(
    IClientCommandService clientCommandService
) : IClientsContextFacade
{
    public async Task<int> CreateClient(string firstName, string lastName, int userId)
    {
        var command = new CreateClientCommand(firstName, lastName, userId);
        var client = await clientCommandService.Handle(command);
        return client?.Id ?? 0;
    }
}