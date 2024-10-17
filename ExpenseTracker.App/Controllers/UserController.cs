using ExpenseTracker.App.Helpers.Attributes;
using ExpenseTracker.Business.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.App.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Login(LoginFormData model)
        {

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateModel]
        public IActionResult Register(LoginFormData model)
        {

            return RedirectToAction("Index", "Home");
        }
    }
}
