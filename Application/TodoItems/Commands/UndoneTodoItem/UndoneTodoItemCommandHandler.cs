using Microsoft.EntityFrameworkCore;
using MediatR;
using Infrastructure;

namespace Application.TodoItems.Commands.UndoneTodoItem
{
    internal sealed class UndoneTodoItemCommandHandler : IRequestHandler<UndoneTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public UndoneTodoItemCommandHandler(AppDbContext todoContext) => _todoContext = todoContext;

        public async Task<Unit> Handle(UndoneTodoItemCommand request, CancellationToken cancellationToken)
        {
            await _todoContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
