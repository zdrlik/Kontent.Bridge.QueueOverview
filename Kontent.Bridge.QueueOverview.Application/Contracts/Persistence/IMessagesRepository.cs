using Kontent.Bridge.QueueOverview.Domain.Entities;

namespace Kontent.Bridge.QueueOverview.Application.Contracts.Persistence
{
    public interface IMessagesRepository
    {
        Task<List<MessageQueueItem>> GetMessagesAsync(string projectId, CancellationToken cancellationToken);
    }
}
