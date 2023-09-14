using Microsoft.EntityFrameworkCore;
using Infrastructure;
using MediatR;

namespace Application.TodoItems.Queries.GetTodayTodoItems
{
    internal sealed class GetTodayTodoItemsQueryHandler : IRequestHandler<GetTodayTodoItemsQuery, TodoItemViewModel[]>
    {
        private readonly AppDbContext _todoContext;

        public GetTodayTodoItemsQueryHandler(AppDbContext todoContext) => _todoContext = todoContext;

        public async Task<TodoItemViewModel[]> Handle(GetTodayTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return null;
            //return await _todoContext.TodoItems
            //    .Where(t => t.DueDate != null && t.DueDate.Value.Date == DateTime.UtcNow.Date)
            //    .Select(t => new TodoItemViewModel(t.Title, t.IsDone, t.DoneDate, t.DueDate))
            //    .ToArrayAsync(cancellationToken);
        }
    }
}
