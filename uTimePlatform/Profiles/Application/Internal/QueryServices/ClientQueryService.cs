    using uTimePlatform.Profiles.Domain.Model.Aggregates;
    using uTimePlatform.Profiles.Domain.Model.Queries;
    using uTimePlatform.Profiles.Domain.Repositories;
    using uTimePlatform.Profiles.Domain.Services;

    namespace uTimePlatform.Profiles.Application.Internal.QueryServices;

    public class ClientQueryService(IClientRepository clientRepository)
        : IClientQueryService
    {
        /// <inheritdoc />
        public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery query)
        {
            return await clientRepository.FindAllAsync();
        }

        /// <inheritdoc />
        public async Task<Client?> Handle(GetClientByIdQuery query)
        {
            return await clientRepository.FindByIdAsync(query.Id);
        }
        
    }