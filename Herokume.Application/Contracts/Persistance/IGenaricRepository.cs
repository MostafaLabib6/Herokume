namespace Herokume.Application.Contracts.Persistance;

public interface IGenaricRepository<T> where T : class
{
    public Task<IReadOnlyList<T>> GetAll();
    public Task<T> Get(Guid id);
    public Task<bool> Exist(Guid Id);
    
    /*
     in memory operations
        `return back task cause using savecontext in function`
     */
    public Task Update(T entity);
    public Task Delete(T entity);
    public Task<T> Add(T entity);

}
