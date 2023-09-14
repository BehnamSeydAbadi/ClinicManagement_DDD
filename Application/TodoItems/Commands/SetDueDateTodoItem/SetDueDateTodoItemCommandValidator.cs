using FluentValidation;
using Infrastructure;

namespace Application.TodoItems.Commands.SetDueDateTodoItem
{
    public class SetDueDateTodoItemCommandValidator : AbstractValidator<SetDueDateTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public SetDueDateTodoItemCommandValidator(AppDbContext todoContext)
        {
            _todoContext = todoContext;
        }
    }
}
