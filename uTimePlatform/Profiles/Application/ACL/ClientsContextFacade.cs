/*

using uTimePlatform.Profiles.Domain.Services; 
using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Model.Queries;
using uTimePlatform.Profiles.Domain.Model.ValueObjects;
using uTimePlatform.Profiles.Interfaces.ACL;



namespace uTimePlatform.Profiles.Application.ACL;

public class ClientsContextFacade(
    IClientCommandService clientCommandService,
    IClientQueryService clientQueryService
) : IClientsContextFacade
{
    
    // inheritedDoc
    public async Task<int> CreateClient(string firstName, string lastName, string email, DateTime birthDate)
    {
        var createClientCommand = new CreateClientCommand(firstName, lastName, email, birthDate);
        var client = await clientCommandService.Handle(createClientCommand);
        return client?.Id ?? 0;
    }

    // inheritedDoc
    public async Task<int> FetchClientIdByEmail(string email)
    {
        var getClientByEmailQuery = new GetClientByEmailQuery(new EmailAddress(email));
        var client = await clientQueryService.Handle(getProfileByEmailQuery);
        return client?.Id ?? 0;
    }
}
/*/