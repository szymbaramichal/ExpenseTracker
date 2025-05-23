using ExpenseTracker.App.Helpers.Attributes;
using ExpenseTracker.Business.Models.Users;
using ExpenseTracker.Business.Services.UserService;
using ExpenseTracker.Core.Constants;
using ExpenseTracker.Core.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.App.Controllers
{
    [Route("[controller]")]
    public class UserController(IUserService userService) : Controller
    {
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionFields.USERNAME);
            HttpContext.Session.Remove(SessionFields.ID);
            HttpContext.Session.Remove(SessionFields.USER_ROLE);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login(LoginFormData model)
        {
            var responseModel = await userService.LoginUser(model);

            if(!responseModel.IsValid)
            {
                ViewBag.ErrorMessage = responseModel.ErrorMessage;
                return View();
            }
           
            RegisterSession(responseModel);
            return RedirectToAction("Index", "Home");
        }


        [HttpPost("Register")]
        [ValidateModel]
        public async Task<IActionResult> Register(LoginFormData model)
        {
            var responseModel = await userService.RegisterUser(model);

            if(!responseModel.IsValid)
            {
                ViewBag.ErrorMessage = responseModel.ErrorMessage;
                return View(nameof(Login));
            }

            RegisterSession(responseModel);
            return RedirectToAction("Index", "Home");
        }

        
        private void RegisterSession(Result<LoginResponseData> responseModel)
        {
            HttpContext.Session.SetString(SessionFields.USERNAME, responseModel.ResultModel.Model.UserName);
            HttpContext.Session.SetString(SessionFields.ID, responseModel.ResultModel.Model.Id.ToString());
            HttpContext.Session.SetString(SessionFields.USER_ROLE, responseModel.ResultModel.Model.Role);
        }
    }
}
