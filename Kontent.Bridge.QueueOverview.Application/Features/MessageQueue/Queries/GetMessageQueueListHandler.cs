using MediatR;

namespace Kontent.Bridge.QueueOverview.Application.Features.MessageQueue.Queries
{
    public class GetMessageQueueListHandler : IRequestHandler<GetMessageQueueListQuery, List<MessageQueueListVm>>   
    {
        public GetMessageQueueListHandler()
        {
        }

        public Task<List<MessageQueueListVm>> Handle(GetMessageQueueListQuery request, CancellationToken cancellationToken)
        {
            // TODO: implement this method
            throw new NotImplementedException();
        }
    }
}
