using MongoDB.Bson;
using MongoDB.Driver;
using TeamBicep.WebApi.Models;

namespace TeamBicep.WebApi.Repositories;
public class TodoRepository(IMongoDatabase db) : MongoRepository<Todo>(db), ITodoRepository
{
    private readonly string _collectionName = "TodoCollection";

    public async Task<List<Todo>> GetAllAsync()
    {
        var collection = db.GetCollection<Todo>(typeof(Todo).Name);
        var filter = Builders<Todo>.Filter.Empty;
        return await collection.Find(filter).ToListAsync();
    }
    public async Task<Todo> GetByIdAsync(string id)
    {
        var collection = db.GetCollection<Todo>(typeof(Todo).Name);
        var filter = Builders<Todo>.Filter.Eq("_id", ObjectId.Parse(id));
        return await collection.Find(id).FirstOrDefaultAsync();
    }

    public async Task AddAsync(Todo todo)
    {
        var collection = db.GetCollection<Todo>(typeof(Todo).Name);
        await collection.InsertOneAsync(todo);

    }
}

