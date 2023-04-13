using Kontent.Bridge.QueueOverview.Application.Features.MessageQueue.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kontent.Bridge.QueueOverview.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageQueueController
    {
        private readonly ISender _mediator;

        public MessageQueueController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetMessages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<List<MessageQueueListVm>> GetMessages(string projectId)
        {
            var query = new GetMessageQueueListQuery { ProjectId = projectId };
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
