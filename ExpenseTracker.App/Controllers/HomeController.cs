using System.Diagnostics;
using ExpenseTracker.Business.Models.Errors;
using ExpenseTracker.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if(HttpContext.Session.GetString(SessionFields.USERNAME) != null)
        {
            return View("LoggedInIndex");
        }
        else
        {
            return View("NotLoggedInIndex");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
