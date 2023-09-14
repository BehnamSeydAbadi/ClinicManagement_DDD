using Application.Interfaces;
using FluentValidation;

namespace Application.TodoItems.Commands.SetDueDateTodoItem
{
    public class SetDueDateTodoItemCommandValidator : AbstractValidator<SetDueDateTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public SetDueDateTodoItemCommandValidator(AppDbContext todoContext)
        {
            _todoContext = todoContext;

            RuleFor(c => c.Id).Must(Any).WithMessage("TodoItem not found.");
        }

        private bool Any(int id) => _todoContext.TodoItems.Any(t => t.Id == id);
    }
}
