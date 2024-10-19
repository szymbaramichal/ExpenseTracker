using System.Diagnostics;
using ExpenseTracker.Business.Models.Errors;
using ExpenseTracker.Business.Services.FamilyService;
using ExpenseTracker.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.App.Controllers;

public class HomeController(IFamilyService familyService) : Controller
{

    public async Task<IActionResult> Index()
    {
        var userId = HttpContext.Session.GetString(SessionFields.ID);
        if(userId is not null)
        {
            var familiesInfo = await familyService.GetFamiliesInfoForUser(int.Parse(userId));
            ViewBag.FamiliesInfo = familiesInfo.ResultModel;
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
