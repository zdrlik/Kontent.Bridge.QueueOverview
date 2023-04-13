using Kontent.Bridge.QueueOverview.Domain.Entities;

namespace Kontent.Bridge.QueueOverview.Application.Contracts.Persistence
{
    public interface IMessagesRepository
    {
        Task<IReadOnlyList<MessageQueueItem>> GetMessagesAsync(string projectId, CancellationToken cancellationToken);
    }
}
