using Dal.EFCore.Repositories;
using Dal.Entities;

namespace Dal.Repositories;

public interface ITeamRepository: IGenericRepository<Team>, IDisposable
{
    Team? GetById(long id);

    Team? GetByName(string name);

    void Delete(long id);
} 