using uTimePlatform.Services.Domain.Model.Aggregates;
using uTimePlatform.Services.Domain.Model.Commands;

namespace uTimePlatform.Services.Domain.Services;

public interface IServiceCommandService
{
    Task<Service?> Handle(CreateServiceCommand command);
    Task<Service?> Handle(UpdateServiceCommand command);
    Task<Service?> Handle(DeleteServiceCommand command);
}