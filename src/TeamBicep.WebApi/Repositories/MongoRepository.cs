using MongoDB.Bson;
using MongoDB.Driver;
using TeamBicep.WebApi.Models;
using TeamBicep.WebApi.Services;

namespace TeamBicep.WebApi.Repositories;

public class MongoRepository<TEntity>(IMongoDatabase db) : IMongoRepository<TEntity>
    where TEntity : class
{
    public async Task<TEntity> GetByIdAsync(string id)
    {
        var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        var filter = Builders<TEntity>.Filter.Eq("_Id", ObjectId.Parse(id));
        return await collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        return await collection.Find(Builders<TEntity>.Filter.Empty).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);

        await collection.InsertOneAsync(entity);
    }
}
