using Application.Interfaces;
using FluentValidation;

namespace Application.TodoItems.Commands.UndoneTodoItem
{
    public class UndoneTodoItemCommandValidation : AbstractValidator<UndoneTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public UndoneTodoItemCommandValidation(AppDbContext todoContext)
        {
            _todoContext = todoContext;

            RuleFor(c => c.Id).Must(Any).WithMessage("TodoItem not found.");
        }

        private bool Any(int id) => _todoContext.TodoItems.Any(t => t.Id == id);
    }
}
