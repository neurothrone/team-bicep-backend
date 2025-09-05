using TeamBicep.WebApi.Models;
using TeamBicep.WebApi.Repositories;

namespace TeamBicep.WebApi.Endpoints;

public static class TodoEndpoints
{
    public static void MapTodoEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("/api/todos")
            .WithTags("Todos");

        group.MapGet(string.Empty, async (ITodoRepository repo) =>
        {
            var todo = await repo.GetAllAsync();
            return Results.Ok(todo);
        });

        // TODO: Add Get Todo By Id Endpoint

        group.MapPost(string.Empty, async (InputTodo todo, ITodoRepository repo) =>
        {
            var todoToCreate = new Todo { Name = todo.Name, Completed = todo.Completed };
            var insertedTodo = await repo.AddAsync(todoToCreate);
            return Results.Created($"/api/todos/{insertedTodo.Id}", insertedTodo);
        });

        // TODO: Add Update By Id Endpoint

        // TODO: Add Delete By Id Endpoint
    }
}