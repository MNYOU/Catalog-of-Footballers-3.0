using Dal.Entities;

namespace Dal.Repositories;

public interface IFootballerRepository: IGenericRepository<Footballer>
{
    Footballer? GetById(long id);

    void Delete(long id);
}