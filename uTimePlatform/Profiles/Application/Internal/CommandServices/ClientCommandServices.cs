using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Repositories;
using uTimePlatform.Profiles.Domain.Services;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Profiles.Application.Internal.CommandServices;

public class ClientCommandServices(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    : IClientCommandService
{
    /// <inheritdoc />
    public async Task<Client?> Handle(CreateClientCommand command)
    {
        var client = new Client(command);

        try
        {
            await clientRepository.AddAsync(client);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return client;
    }
}