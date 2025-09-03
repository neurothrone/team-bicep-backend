namespace TeamBicep.WebApi.Repositories;


public interface IMongoRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(string id);
    Task AddAsync(TEntity entity);
}
