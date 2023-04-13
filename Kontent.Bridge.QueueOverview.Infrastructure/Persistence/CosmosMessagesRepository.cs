using Kontent.Bridge.QueueOverview.Application.Contracts.Persistence;
using Kontent.Bridge.QueueOverview.Domain.Entities;

namespace Kontent.Bridge.QueueOverview.Infrastructure.Persistence
{
    public class CosmosMessagesRepository : IMessagesRepository
    {
        public CosmosMessagesRepository()
        {
        }

        public async Task<IReadOnlyList<MessageQueueItem>> GetMessagesAsync(string projectId, CancellationToken cancellationToken)
        {
            // TODO: Implement this method
            return Enumerable.Empty<MessageQueueItem>().ToList();
        }
    }
}
