using AutoMapper;
using Kontent.Bridge.QueueOverview.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Kontent.Bridge.QueueOverview.Application.Features.MessageQueue.Queries
{
    public class GetMessageQueueListHandler : IRequestHandler<GetMessageQueueListQuery, List<MessageQueueListVm>>   
    {
        private readonly IMessagesRepository _messagesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMessageQueueListHandler> _logger;

        public GetMessageQueueListHandler(IMessagesRepository messagesRepository, IMapper mapper, ILogger<GetMessageQueueListHandler> logger)
        {
            _messagesRepository = messagesRepository ?? throw new ArgumentNullException(nameof(messagesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<MessageQueueListVm>> Handle(GetMessageQueueListQuery request, CancellationToken cancellationToken)
        {
            var allMessages = await _messagesRepository.GetMessagesAsync(request.ProjectId, cancellationToken);
            _logger.LogDebug("Retrieved {Count} messages", allMessages.Count);
            return _mapper.Map<List<MessageQueueListVm>>(allMessages);
        }
    }
}
