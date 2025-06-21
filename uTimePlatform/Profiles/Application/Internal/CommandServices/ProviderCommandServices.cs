using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.Commands;
using uTimePlatform.Profiles.Domain.Repositories;
using uTimePlatform.Profiles.Domain.Services;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Profiles.Application.Internal.CommandServices;

public class ProviderCommandServices(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
    : IProviderCommandService
{
    public async Task<Provider?> Handle(CreateProviderCommand command)
    {
        var provider = new Provider(command);

        try
        {
            await providerRepository.AddAsync(provider);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return provider;
    }
}