namespace uTimePlatform.Workers.Domain.Model.Commands
{
    public record DeleteWorkerCommand
    {
        public DeleteWorkerCommand(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Worker ID must be a positive number", nameof(id));
            }
        }
    }
}