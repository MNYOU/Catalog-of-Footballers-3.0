using Dal.Entities;
using Dal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dal.EFCore.Repositories;

public class FootballerRepository : GenericRepository<Footballer>, IFootballerRepository
{
    public FootballerRepository(DataContext context) : base(context, context.Footballers)
    {
    }
    
    public Footballer? GetById(long id)
    {
        return DbSet.AsQueryable()
            .Include(f => f.Team)
            .FirstOrDefault(f => f.Id == id);
    }

    public void Delete(long id)
    {
        var footballer = GetById(id);
        if (footballer != null)
            Delete(footballer);
    }
}