using HelloWorld.Models.UserService;
using HelloWorld.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using User = HelloWorld.Models.UserService;

namespace HelloWorld.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterView());
        }

        [HttpPost]
        public IActionResult Register(RegisterView model)
        {
            bool success = _userService.Register(model);
            if (success == false || ModelState.IsValid == false)
                return View(model);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public IActionResult Login(LoginView model)
        {
            bool success = _userService.Login(model);
            if (success == false || ModelState.IsValid == false)
                return View(model);
            else
            {
                return RedirectToAction("Success");
            }

        }

        public IActionResult Success()
        {
            return View();
        }
        
    }
}