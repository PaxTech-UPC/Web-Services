using uTimePlatform.Profiles.Domain.Model.Aggregates;
using uTimePlatform.Profiles.Domain.Model.Commands;

namespace uTimePlatform.Profiles.Domain.Services;

public interface IProviderCommandService
{
    Task<Provider?> Handle(CreateProviderCommand command);
}