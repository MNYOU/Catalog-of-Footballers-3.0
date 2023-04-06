namespace Dal.Repositories;

public interface IGenericRepository<T> where T: class
{
    void SaveChanges();

    Task<int> SaveChangesAsync();

    IQueryable<T> GetAll();

    IQueryable<T> FindBy(Predicate<T> predicate);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
}