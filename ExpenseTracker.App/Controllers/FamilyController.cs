using System;
using ExpenseTracker.App.Helpers.Attributes;
using ExpenseTracker.Business.Models.Families;
using ExpenseTracker.Business.Services.ExpensesService;
using ExpenseTracker.Business.Services.FamilyService;
using ExpenseTracker.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.App.Controllers;

[Route("[controller]")]
public class FamilyController(IFamilyService familyService, IExpensesService expensesService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("JoinFamily")]
    [ValidateModel(ActionName = nameof(Index), ControllerName = "Family")]
    public async Task<IActionResult> JoinFamily(FamilyJoinCreationData model)
    {
        var userId = HttpContext.Session.GetString(SessionFields.ID);
        var familyInfoModel = await familyService.JoinFamily(int.Parse(userId), model.FamilyCode);
        if(!familyInfoModel.IsValid)
        {
            TempData["ErrorMessage"] = familyInfoModel.ErrorMessage;
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(FamilyPage), "Family", new { id = familyInfoModel.ResultModel.Id });
    }

    [HttpGet("FamilyPage/{id}")]
    public async Task<IActionResult> FamilyPage(int id)
    {
        var userId = HttpContext.Session.GetString(SessionFields.ID);

        var familyViewModel = await familyService.GetFamilyDetailsForUser(int.Parse(userId), id);
        
        if(!familyViewModel.IsValid)
        {
            TempData["ErrorMessage"] = familyViewModel.ErrorMessage;
            return RedirectToAction(nameof(Index));
        }

        familyViewModel.ResultModel.Expenses = await expensesService.GetExpensesForFamily(id);

        return View(familyViewModel.ResultModel);
    }

    [HttpGet("RemoveUser/{userId}/{familyId}")]
    public async Task<IActionResult> RemoveUser(int userId, int familyId)
    {
        var currentUserId = int.Parse(HttpContext.Session.GetString(SessionFields.ID));

        if (await familyService.IsUserOwner(currentUserId, familyId))
        {
            await familyService.RemoveUserFromFamily(userId, familyId);
            
            return RedirectToAction(nameof(FamilyPage), new { id = familyId });
        }

        return Unauthorized();
    }

    [HttpPost("CreateFamily")]
    [ValidateModel(ActionName = nameof(Index), ControllerName = "Family")]
    public async Task<IActionResult> CreateFamily(FamilyJoinCreationData model)
    {
        var userId = HttpContext.Session.GetString(SessionFields.ID);
        var familyInfoModel = await familyService.CreateFamily(int.Parse(userId), model);

        if(!familyInfoModel.IsValid)
        {
            TempData["ErrorMessage"] = familyInfoModel.ErrorMessage;
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(FamilyPage), "Family", new { id = familyInfoModel.ResultModel.Id });
    }

    [HttpGet("GenerateInvitationCode")]
    public async Task<IActionResult> GenerateInvitationCode(int familyId)
    {
        var userId = HttpContext.Session.GetString(SessionFields.ID);
        var familyInfoModel = await familyService.GenerateInvitationCode(familyId, int.Parse(userId));

        if(!familyInfoModel.IsValid)
        {
            TempData["ErrorMessage"] = familyInfoModel.ErrorMessage;
            return RedirectToAction(nameof(FamilyPage), "Family", new { id = familyId });
        }

        TempData["InvitationCode"] = familyInfoModel.ResultModel.FamilyInvitationCode;

        return RedirectToAction(nameof(FamilyPage), "Family", new { id = familyInfoModel.ResultModel.Id });
    }
    
    [HttpGet("Description/{familyId}")]
    public async Task<IActionResult> Description(int familyId)
    {
        var userId = HttpContext.Session.GetString(SessionFields.ID);
        var family = await familyService.GetFamilyDetailsForUser(int.Parse(userId), familyId);
        
        if (family == null)
        {
            return NotFound();
        }

        var viewModel = new FamilyDescriptionViewModel
        {
            FamilyId = family.ResultModel.Id,
            Description = family.ResultModel.Description
        };

        return View(viewModel);
    }

    [HttpPost("EditDescription")]
    public async Task<IActionResult> EditDescription(FamilyDescriptionViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await familyService.UpdateFamilyDescription(model.FamilyId, model.Description);

        return RedirectToAction(nameof(FamilyPage), new { id = model.FamilyId });
    }
}
