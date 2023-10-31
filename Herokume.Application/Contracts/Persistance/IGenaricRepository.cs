namespace Herokume.Application.Contracts.Persistance;

public interface IGenaricRepository<T> where T : class
{
    public Task<IReadOnlyList<T>> GetAll();
    public Task<T> Get(Guid id);
    public Task<bool> Save();
    public Task<bool> Exist(T entity);
    
    /*
     in memory operations
     */
    public void Update(T entity);
    public void Delete(T entity);
    public void Add(T entity);

}
