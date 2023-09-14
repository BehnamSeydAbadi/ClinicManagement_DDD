using FluentValidation;
using Infrastructure;

namespace Application.TodoItems.Commands.UndoneTodoItem
{
    public class UndoneTodoItemCommandValidation : AbstractValidator<UndoneTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public UndoneTodoItemCommandValidation(AppDbContext todoContext)
        {
            _todoContext = todoContext;
        }
    }
}
