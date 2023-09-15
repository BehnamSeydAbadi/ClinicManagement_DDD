using Domain.Contracts.Common;
using MediatR;

namespace Application.Common;

public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
       where TCommand : IRequest<TResult>
{
    private readonly IMediator _mediator;

    public CommandHandler(IMediator mediator) => _mediator = mediator;

    public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);

    protected async Task PublishAsync(IEnumerable<DomainEvent> events)
    {
        foreach (var @event in events) await _mediator.Publish(@event);
    }

    protected int GenerateId()
              => DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss:fff").GetHashCode();
}
