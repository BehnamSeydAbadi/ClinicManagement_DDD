using Application.Interfaces;
using Domain.TodoItems;
using Infrastructure.TodoItems;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext, Application.Interfaces.AppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfiguration(TodoItemConfiguration.Config);

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
