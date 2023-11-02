using Herokume.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Herokume.Persisitance.Repositories;

public class GenaricRepository<T> : IGenaricRepository<T> where T : class
{
    private readonly HerokumeDbContext _dbContext;

    public GenaricRepository(HerokumeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T> Add(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Exist(Guid Id)
    {
        var entity = await Get(Id);
        return entity != null;
    }

    public async Task<T> Get(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
