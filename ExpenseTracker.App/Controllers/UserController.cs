using ExpenseTracker.App.Helpers.Attributes;
using ExpenseTracker.Business.Models.Users;
using ExpenseTracker.Business.Services.UserService;
using ExpenseTracker.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.App.Controllers
{
    public class UserController(IUserService userService) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Login(LoginFormData model)
        {
            var responseModel = await userService.LoginUser(model);

            if(responseModel.IsValid)
            {
                HttpContext.Session.SetString(SessionFields.USERNAME, responseModel.ResultModel.Model.UserName);
                HttpContext.Session.SetString(SessionFields.USER_ROLE, responseModel.ResultModel.Model.Role);
            }
            else
            {
                ViewBag.ErrorMessage = responseModel.ErrorMessage;
                return View();
            }
           
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Register(LoginFormData model)
        {
            var responseModel = await userService.RegisterUser(model);

            if(responseModel.IsValid)
            {
                HttpContext.Session.SetString(SessionFields.USERNAME, responseModel.ResultModel.Model.UserName);
                HttpContext.Session.SetString(SessionFields.USER_ROLE, responseModel.ResultModel.Model.Role);
            }
            else
            {
                ViewBag.ErrorMessage = responseModel.ErrorMessage;
                return View(nameof(Login));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
