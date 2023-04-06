using System.Collections.Generic;
using Dal.Entities;
using Dal.ViewModels;

namespace Logic.Interfaces;

public interface IFootballerManager
{
    IEnumerable<FootballerViewModel> GetAll();

    FootballerViewModel? GetById(long id);

    bool Add(FootballerViewModel model);

    bool Update(FootballerViewModel model);

    bool Delete(long id);
}