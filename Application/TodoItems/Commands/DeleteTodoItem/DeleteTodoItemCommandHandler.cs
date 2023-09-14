using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Commands.DeleteTodoItem
{
    internal sealed class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public DeleteTodoItemCommandHandler(AppDbContext todoContext) => _todoContext = todoContext;

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            //var todoItem = await _todoContext.TodoItems.SingleOrDefaultAsync(t => t.Id == request.Id);

            //_todoContext.TodoItems.Remove(todoItem);

            await _todoContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
