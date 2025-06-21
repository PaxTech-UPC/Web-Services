using uTimePlatform.Services.Domain.Model.Aggregates;
using uTimePlatform.Services.Domain.Model.Commands;
using uTimePlatform.Services.Domain.Repositories;
using uTimePlatform.Services.Domain.Services;
using uTimePlatform.Shared.Domain.Repositories;

namespace uTimePlatform.Services.Application.Internal.CommandServices;

public class ServiceCommandService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
    : IServiceCommandService
{
    public async Task<Service?> Handle(CreateServiceCommand command)
    {
        var service = new Service(command);

        try
        {
            await serviceRepository.AddAsync(service);
            await unitOfWork.CompleteAsync();
            return service;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Service?> Handle(UpdateServiceCommand command)
    {
        var service = await serviceRepository.FindByIdAsync(command.Id);
        if (service is null) return null;

        service.UpdateInformation(
            command.Name,
            command.Duration,
            command.Price,
            command.Status,
            command.Description
        );

        try
        {
            serviceRepository.Update(service);
            await unitOfWork.CompleteAsync();
            return service;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Service?> Handle(DeleteServiceCommand command)
    {
        var service = await serviceRepository.FindByIdAsync(command.Id);
        if (service is null) return null;

        try
        {
            serviceRepository.Remove(service);
            await unitOfWork.CompleteAsync();
            return service;
        }
        catch (Exception)
        {
            return null;
        }
    }
}