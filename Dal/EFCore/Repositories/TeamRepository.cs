using Dal.Entities;
using Dal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dal.EFCore.Repositories;

public class TeamRepository: GenericRepository<Team>, ITeamRepository
{
    public TeamRepository(DataContext context): base(context, context.Teams)
    {
    }

    public Team? GetById(long id)
    {
        return DbSet.FirstOrDefault(t => t.Id == id);
    }

    public Team? GetByName(string name)
    {
        return DbSet.FirstOrDefault(t => t.Name == name);
    }

    public void Delete(long id)
    {
        var team = GetById(id);
        if (team != null)
            Delete(team);
    }
}