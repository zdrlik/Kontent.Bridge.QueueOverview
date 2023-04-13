using AutoMapper;
using Kontent.Bridge.QueueOverview.Application.Features.MessageQueue.Queries;
using Kontent.Bridge.QueueOverview.Domain.Entities;

namespace Kontent.Bridge.QueueOverview.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MessageQueueItem, MessageQueueListVm>();
        }
    }
}
