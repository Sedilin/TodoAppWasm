using Application.DaoInterfaces;
using Domain;

namespace FileData.DAOs;

public class TodoFileDao : ITodoDao
{
    private readonly FileContext context;

    public TodoFileDao(FileContext fileContext)
    {
        context = fileContext;
    }

    public Task<Todo> CreateAsync(Todo todo)
    {
        int todoId = 1;
        if (context.Todos.Any())
        {
            todoId = context.Todos.Max(t => t.Id);
            todoId++;
        }

        todo.Id = todoId;
        
        context.Todos.Add(todo);
        context.SaveChanges();

        return Task.FromResult(todo);
    }
}