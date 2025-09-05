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
        group.MapGet("/{id}", async (string id, ITodoRepository repo) =>
        {
            var todo = await repo.GetByIdAsync(id);
            return todo is not null ? Results.Ok(todo) : Results.NotFound();
        });

        group.MapPost(string.Empty, async (InputTodo todo, ITodoRepository repo) =>
        {
            var todoToCreate = new Todo { Name = todo.Name, Completed = todo.Completed };
            var insertedTodo = await repo.AddAsync(todoToCreate);
            return Results.Created($"/api/todos/{insertedTodo.Id}", insertedTodo);
        });

        // TODO: Add Update By Id Endpoint
        group.MapPut("/{id}", async (string id, InputTodo todo, ITodoRepository repo) =>
        {
            var todoToUpdate = new Todo { Name = todo.Name, Completed = todo.Completed };
            var updatedTodo = await repo.UpdateByIdAsync(id, todoToUpdate);
            return updatedTodo is not null ? Results.Ok(updatedTodo) : Results.NotFound();
        });

        // TODO: Add Delete By Id Endpoint
        group.MapDelete("/{id}", async (string id, ITodoRepository repo) =>
        {
            var deletedTodo = await repo.DeleteByIdAsync(id);
            return deletedTodo is not null ? Results.Ok(deletedTodo) : Results.NotFound();
        });
    }
}