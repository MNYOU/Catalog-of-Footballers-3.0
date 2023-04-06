using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AutoMapper;
using Dal.EFCore.Repositories;
using Dal.Entities;
using Dal.Repositories;
using Dal.ViewModels;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.Implementations;

public class FootballerManager: IFootballerManager
{
    private readonly IMapper _mapper;
    private readonly IFootballerRepository _repository;
    private readonly ITeamManager _teamManager;
    
    public FootballerManager(IMapper mapper,IFootballerRepository repository, ITeamManager teamManager)
    {
        _mapper = mapper;
        _repository = repository;
        _teamManager = teamManager;
    }
    
    public IEnumerable<FootballerViewModel> GetAll()
    {
        return _repository
            .GetAll()
            .Include(f => f.Team)
            .Select(f => _mapper.Map<FootballerViewModel>(f));
    }

    public FootballerViewModel? GetById(long id)
    {
        return _mapper.Map<FootballerViewModel>(_repository.GetById(id));
    }

    public bool Add(FootballerViewModel model)
    {
        var footballer = _mapper.Map<Footballer>(model);
        var team = _teamManager.Get(model.Team);
        footballer.Team = team ?? _mapper.Map<Team>(model.Team);
        
        _repository.Add(footballer);
        _repository.SaveChanges();
        return true;
    }

    public bool Update(FootballerViewModel model)
    {
        var footballer = _mapper.Map<Footballer>(model);
        var team = _teamManager.Get(model.Team);
        footballer.Team = team ?? _mapper.Map<Team>(model.Team);

        _repository.Update(footballer);
        _repository.SaveChanges();
        return true;
    }

    public bool Delete(long id)
    {
        var footballer = _repository.GetById(id);
        if (footballer is null) 
            return false;
        _repository.Delete(id);
        _repository.SaveChanges();
        return true;
    }
}