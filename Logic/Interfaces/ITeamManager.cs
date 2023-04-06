using Dal.Entities;
using Dal.ViewModels;

namespace Logic.Interfaces;

public interface ITeamManager
{
    Team? Get(TeamViewModel model);
    
    Team? GetById(long id);
    
    IEnumerable<TeamViewModel> GetAll();
    
    TeamViewModel? GetViewModelById(long id);
    
    bool Add(TeamViewModel model);
}