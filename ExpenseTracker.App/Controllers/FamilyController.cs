using System;
using ExpenseTracker.App.Helpers.Attributes;
using ExpenseTracker.Business.Models.Families;
using ExpenseTracker.Business.Services.FamilyService;
using ExpenseTracker.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.App.Controllers;

public class FamilyController(IFamilyService familyService) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateModel(ActionName = nameof(Index), ControllerName = "Family")]
    public async Task<IActionResult> JoinFamily(FamilyJoinCreationData model)
    {
        return RedirectToAction("Privacy", "Home");
    }

    public async Task<IActionResult> FamilyPage(int id)
    {
        return View(id);
    }

    [HttpPost]
    [ValidateModel(ActionName = nameof(Index), ControllerName = "Family")]
    public async Task<IActionResult> CreateFamily(FamilyJoinCreationData model)
    {
        var userId = HttpContext.Session.GetString(SessionFields.ID);
        var familyInfoModel = await familyService.CreateFamily(int.Parse(userId), model);

        return RedirectToAction(nameof(FamilyPage), "Family", new { id = familyInfoModel.ResultModel.Id });
    }
}
