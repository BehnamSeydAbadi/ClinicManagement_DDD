using Infrastructure;
using Application.TodoItems.Commands.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Commands.DoneTodoItem
{
    internal sealed class DoneTodoItemCommandHandler : IRequestHandler<DoneTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public DoneTodoItemCommandHandler(AppDbContext todoContext) => _todoContext = todoContext;

        public async Task<Unit> Handle(DoneTodoItemCommand request, CancellationToken cancellationToken)
        {
            //var todoItem = await _todoContext.TodoItems.SingleOrDefaultAsync(t => t.Id == request.Id);

            //todoItem.MakeItDone();

            //_todoContext.TodoItems.Update(todoItem);

            await _todoContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
