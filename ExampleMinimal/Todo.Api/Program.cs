
using Microsoft.EntityFrameworkCore;
using Todo.Api;

var builder = WebApplication.CreateBuilder(args);

#region Configuring - DI
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("ToDoList"));

#endregion
var app = builder.Build();

#region Configuring request pipe-line
////Configuring pipeline using methods:

app.MapGet("/todoitems",async (TodoDb db)=>
    await db.Todos.ToListAsync());

app.MapGet("/todoitems/{id}", async (int id,TodoDb db) =>
    await db.Todos.FindAsync(id));

app.MapPost("/todoitems", async (TodoItem todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, TodoItem inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();
    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is TodoItem todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

#endregion

app.Run();
