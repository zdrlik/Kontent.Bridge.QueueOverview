using FluentValidation;
using MediatR;

namespace Kontent.Bridge.QueueOverview.Application.Features.MessageQueue.Queries
{
    public class GetMessageQueueListQuery : IRequest<List<MessageQueueListVm>>
    {
        public string ProjectId { get; set; }
    }

    public class GetMessageQueueListQueryValidator : AbstractValidator<GetMessageQueueListQuery>
    {
        public GetMessageQueueListQueryValidator()
        {
            RuleFor(p => p.ProjectId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
