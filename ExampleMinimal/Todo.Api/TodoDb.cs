using Microsoft.EntityFrameworkCore;

namespace Todo.Api;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> dbContextOptions) 
        : base(dbContextOptions)
    {       
    }

    public DbSet<TodoItem> Todos { get; set; }
}
