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
        public IActionResult Login(LoginFormData model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Register(LoginFormData model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
