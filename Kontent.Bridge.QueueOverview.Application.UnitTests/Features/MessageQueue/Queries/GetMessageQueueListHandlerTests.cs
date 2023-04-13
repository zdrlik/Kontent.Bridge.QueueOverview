using AutoMapper;
using FluentAssertions;
using Kontent.Bridge.QueueOverview.Application.Contracts.Persistence;
using Kontent.Bridge.QueueOverview.Application.Features.MessageQueue.Queries;
using Kontent.Bridge.QueueOverview.Application.Mappings;
using Kontent.Bridge.QueueOverview.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace Kontent.Bridge.QueueOverview.Application.UnitTests.Features.MessageQueue.Queries
{
    public class GetMessageQueueListHandlerTests 
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldReturnMessageQueueListVm()
        {
            // Arrange
            var projectId = Guid.NewGuid().ToString();
            var query = new GetMessageQueueListQuery() { ProjectId = projectId };

            var handler = new GetMessageQueueListHandlerBuilder()
                .WithEmptyMessageQueue()
                .Build();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldReturnListWithCorrectCount()
        {
            // Arrange
            var projectId = Guid.NewGuid().ToString();
            var query = new GetMessageQueueListQuery() { ProjectId = projectId };
            var messageQueueItems = Enumerable.Range(1, 5).Select(i => new MessageQueueItem() { ProjectId = projectId });
            var handler = new GetMessageQueueListHandlerBuilder()
                .WithMessageQueueItems(messageQueueItems)
                .Build();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().HaveCount(5);
        }
    }

    internal class GetMessageQueueListHandlerBuilder
    {
        private IMessagesRepository _messagesRepository;
        private IMapper _mapper;
        private ILogger<GetMessageQueueListHandler> _logger;

        public GetMessageQueueListHandlerBuilder()
        {
            _messagesRepository = new Mock<IMessagesRepository>().Object;
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
            _logger = NullLogger<GetMessageQueueListHandler>.Instance;
        }

        public GetMessageQueueListHandlerBuilder WithEmptyMessageQueue()
        {
            return WithMessageQueueItems(Enumerable.Empty<MessageQueueItem>());
        }

        public GetMessageQueueListHandlerBuilder WithMessageQueueItems(IEnumerable<MessageQueueItem> items)
        {
            var messagesRepository = new Mock<IMessagesRepository>();
            messagesRepository.Setup(m => m.GetMessagesAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(items.ToList());

            return WithMessagesRepository(messagesRepository.Object);
        }

        public GetMessageQueueListHandlerBuilder WithMessagesRepository(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
            return this;
        }

        public GetMessageQueueListHandler Build()
        {
            return new GetMessageQueueListHandler(_messagesRepository, _mapper, _logger);
        }
    }
}
