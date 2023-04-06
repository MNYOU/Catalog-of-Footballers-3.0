using AutoMapper;
using Dal.Entities;
using Dal.Repositories;
using Dal.ViewModels;
using Logic.Interfaces;

namespace Logic.Implementations;

public class TeamManager : ITeamManager
{
    private readonly IMapper _mapper;
    private readonly ITeamRepository _repository;

    public TeamManager(IMapper mapper, ITeamRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public IEnumerable<TeamViewModel> GetAll()
    {
        return _repository
            .GetAll()
            .Select(t => _mapper.Map<TeamViewModel>(t));
    }

    public Team? Get(TeamViewModel model)
    {
        if (model.Id != 0)
        {
            return GetById(model.Id);
        }

        return _repository.GetByName(model.Name);
    }

    public TeamViewModel? GetViewModel(TeamViewModel model)
    {
        var team = Get(model);
        return _mapper.Map<TeamViewModel>(team);
    }

    public TeamViewModel? GetViewModelById(long id)
    {
        var team = _repository.GetById(id);
        return _mapper.Map<TeamViewModel>(team);
    }

    public Team? GetById(long id)
    {
        return _repository.GetById(id);
    }

    public bool Add(TeamViewModel model)
    {
        var team = _mapper.Map<Team>(model);
        _repository.Add(team);
        _repository.SaveChanges();
        return true;
    }
}