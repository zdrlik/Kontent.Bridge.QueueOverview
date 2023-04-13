using Kontent.Bridge.QueueOverview.Domain.Entities;

namespace Kontent.Bridge.QueueOverview.Application.Contracts.Persistence
{
    public interface IMessagesRepository
    {
        Task<IReadOnlyList<MessageQueueItem>> GetMessages(string projectId, CancellationToken cancellationToken);
    }
}
