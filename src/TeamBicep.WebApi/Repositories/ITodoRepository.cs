using System.Formats.Tar;
using TeamBicep.WebApi.Models;

namespace TeamBicep.WebApi.Repositories;

public interface ITodoRepository
{
    Task AddAsync(Todo todo);
    Task<Todo> GetByIdAsync(string id);
    Task<List<Todo>> GetAllAsync();
}
