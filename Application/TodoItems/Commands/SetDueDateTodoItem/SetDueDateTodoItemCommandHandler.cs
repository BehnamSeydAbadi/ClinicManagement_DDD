﻿using Infrastructure;
using MediatR;

namespace Application.TodoItems.Commands.SetDueDateTodoItem
{
    internal class SetDueDateTodoItemCommandHandler : IRequestHandler<SetDueDateTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public SetDueDateTodoItemCommandHandler(AppDbContext todoContext) => _todoContext = todoContext;

        public async Task<Unit> Handle(SetDueDateTodoItemCommand request, CancellationToken cancellationToken)
        {
            //var todoItem = await _todoContext.TodoItems
            //    .SingleOrDefaultAsync(t => t.Id == request.Id);

            //todoItem.SetDueDate(request.DueDate);

            //_todoContext.TodoItems.Update(todoItem);

            await _todoContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
