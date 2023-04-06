using Dal.ViewModels;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_of_Footballers.Controllers;

[Route("footballer")]
public class FootballController : Controller
{
    private readonly IFootballerManager _footballerManager;
    private readonly ITeamManager _teamManager;

    public FootballController(IFootballerManager footballerManager, ITeamManager teamManager)
    {
        _teamManager = teamManager;
        _footballerManager = footballerManager;
    }

    [HttpGet("add")]
    public IActionResult AddFootballer()
    {
        ViewBag.Teams = _teamManager.GetAll();
        return View();
    }

    [HttpPost("add")]
    public IActionResult AddFootballer([FromForm] FootballerViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = _footballerManager.Add(model);
            return View(result ? "Success" : "Error");
        }

        ViewBag.Teams = _teamManager.GetAll();
        return View(model);
    }

    [HttpGet("all")]
    public IActionResult GetAll()
    {
        var viewModels = _footballerManager.GetAll();
        return View(viewModels);
    }

    [HttpGet("update/{id:long}")]
    public IActionResult Update([FromRoute] long id)
    {
        var footballer = _footballerManager.GetById(id);
        if (footballer is null)
        {
            View("Error");
        }

        ViewBag.Teams = _teamManager.GetAll();
        return View(footballer);
    }

    [HttpPost("update/{id:long}")]
    public IActionResult Update([FromRoute] long id, [FromForm] FootballerViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var result = _footballerManager.Update(model);
        if (!result)
            return View("Error");
        return RedirectToAction(nameof(GetAll));
    }

    [HttpPost("delete/{id:long}")]
    public IActionResult Delete(long id)
    {
        var result = _footballerManager.Delete(id);
        if (!result)
            return View("Error");
        return RedirectToAction(nameof(GetAll));
    }
}