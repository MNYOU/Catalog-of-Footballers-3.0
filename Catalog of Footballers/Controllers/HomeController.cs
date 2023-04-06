using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Catalog_of_Footballers.Controllers;

[Route("home")]
public class HomeController: Controller
{
    [HttpGet("about")]
    public IActionResult About()
    {
        return View();
    }
}