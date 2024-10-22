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
        var userId = HttpContext.Session.GetString(SessionFields.ID);

        var familyViewModel = await familyService.GetFamilyDetailsForUser(int.Parse(userId), id);
        
        if(!familyViewModel.IsValid)
        {
            ViewBag.ErrorMessage = familyViewModel.ErrorMessage;
            return View();
        }

        return View(familyViewModel.ResultModel);
    }

    [HttpPost]
    [ValidateModel(ActionName = nameof(Index), ControllerName = "Family")]
    public async Task<IActionResult> CreateFamily(FamilyJoinCreationData model)
    {
        var userId = HttpContext.Session.GetString(SessionFields.ID);
        var familyInfoModel = await familyService.CreateFamily(int.Parse(userId), model);

        if(!familyInfoModel.IsValid)
        {
            ViewBag.ErrorMessage = familyInfoModel.ErrorMessage;
            return View();
        }

        return RedirectToAction(nameof(FamilyPage), "Family", new { id = familyInfoModel.ResultModel.Id });
    }
}
