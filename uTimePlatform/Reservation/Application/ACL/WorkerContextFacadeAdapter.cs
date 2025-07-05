    using uTimePlatform.Reservation.Interfaces.ACL;
    using uTimePlatform.Workers.Domain.Model.Aggregates;
    using uTimePlatform.Workers.Domain.Services;

    namespace uTimePlatform.Reservation.Application.ACL;

    public class WorkerContextFacadeAdapter : IWorkerContextFacade
    {
        private readonly uTimePlatform.Workers.Interfaces.ACL.IWorkerContextFacade _workerContext;
        
        public WorkerContextFacadeAdapter(uTimePlatform.Workers.Interfaces.ACL.IWorkerContextFacade workerContext)
        {
            _workerContext = workerContext;
        }

        public async Task<Worker?> GetWorkerByIdAsync(int id)
        {
            return await _workerContext.GetWorkerByIdAsync(id);
        }
    }