using Microsoft.EntityFrameworkCore;
using TodoApi.Models.Domain;

namespace TodoApi.Data;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    public DbSet<PriorityItem> PriorityItems { get; set; }
}