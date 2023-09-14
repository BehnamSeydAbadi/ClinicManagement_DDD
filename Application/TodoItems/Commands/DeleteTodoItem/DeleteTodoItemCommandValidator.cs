using FluentValidation;
using Infrastructure;

namespace Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public DeleteTodoItemCommandValidator(AppDbContext todoContext)
        {
            _todoContext = todoContext;

            //RuleFor(c => c.Id).Must(Any).WithMessage("TodoItem not found.");
        }

        //private bool Any(int id) => _todoContext.TodoItems.Any(t => t.Id == id);
    }
}
