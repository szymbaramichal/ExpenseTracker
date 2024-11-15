using System;
using ExpenseTracker.Business.Models.Expenses;
using ExpenseTracker.Business.Services.ExpensesService;
using ExpenseTracker.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.App.Controllers;

[Route("[controller]")]
public class ExpenseController(IExpensesService expensesService) : Controller
{
    [HttpGet("Add")]
    public IActionResult Add(int id)
    {
        var model = new ExpenseFormModel
        {
            FamilyId = id,
            UserId = int.Parse(HttpContext.Session.GetString(SessionFields.ID))
        };

        return View(model);
    }

    [HttpPost("AddExpense")]
    public async Task<IActionResult> AddExpense(ExpenseFormModel expenseFormModel)
    {
        await expensesService.AddExpenseToFamily(expenseFormModel);
        
        return RedirectToAction("FamilyPage", "Family", new { id = expenseFormModel.FamilyId });
    }
}
 