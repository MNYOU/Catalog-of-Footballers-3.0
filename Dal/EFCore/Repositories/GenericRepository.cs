using Dal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dal.EFCore.Repositories;

public class GenericRepository<T>: IGenericRepository<T>, IDisposable where T : class
{
    protected readonly DataContext Context;
    protected readonly DbSet<T> DbSet;
    protected GenericRepository(DataContext context, DbSet<T> dbSet)
    {
        Context = context;
        DbSet = dbSet;
    }
    
    public void Dispose()
    {
        Context.Dispose();
        GC.SuppressFinalize(this);
    }
    
    public void SaveChanges()
    {
        Context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
        return DbSet;
    }

    public IQueryable<T> FindBy(Predicate<T> predicate)
    {
        return DbSet.Where(x => predicate(x));
    }

    public void Add(T entity)
    {
        DbSet.Add(entity);
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }
}