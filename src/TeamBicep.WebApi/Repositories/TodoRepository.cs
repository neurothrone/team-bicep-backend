using MongoDB.Bson;
using MongoDB.Driver;
using TeamBicep.WebApi.Models;

namespace TeamBicep.WebApi.Repositories;

public class TodoRepository(IMongoDatabase db) : ITodoRepository
{
    private const string CollectionName = "todos";

    public async Task<List<Todo>> GetAllAsync()
    {
        var collection = db.GetCollection<Todo>(CollectionName);
        var filter = Builders<Todo>.Filter.Empty;
        return await collection
            .Find(filter)
            .ToListAsync();
    }

    public async Task<Todo> GetByIdAsync(string id)
    {
        var collection = db.GetCollection<Todo>(CollectionName);
        var filter = Builders<Todo>.Filter.Eq("_id", ObjectId.Parse(id));
        return await collection
            .Find(filter)
            .FirstOrDefaultAsync();
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        var collection = db.GetCollection<Todo>(CollectionName);
        await collection.InsertOneAsync(todo);
        return todo;
    }
}