using Domain.TodoItems;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface AppDbContext
    {
        DbSet<TodoItem> TodoItems { get; set; }

        Task SaveChangesAsync();
    }
}
