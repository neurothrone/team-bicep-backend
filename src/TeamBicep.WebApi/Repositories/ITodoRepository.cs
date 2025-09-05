using TeamBicep.WebApi.Models;

namespace TeamBicep.WebApi.Repositories;

public interface ITodoRepository
{
    Task<List<Todo>> GetAllAsync();
    Task<Todo> GetByIdAsync(string id);
    Task<Todo> AddAsync(Todo todo);
}