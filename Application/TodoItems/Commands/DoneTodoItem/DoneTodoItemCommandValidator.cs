using FluentValidation;
using Infrastructure;

namespace Application.TodoItems.Commands.DoneTodoItem
{

    public class DoneTodoItemCommandValidator : AbstractValidator<DoneTodoItemCommand>
    {
        private readonly AppDbContext _todoContext;

        public DoneTodoItemCommandValidator(AppDbContext todoContext)
        {
            _todoContext = todoContext;
        }
    }
}
