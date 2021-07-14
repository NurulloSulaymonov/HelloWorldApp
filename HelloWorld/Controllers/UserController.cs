using HelloWorld.Models.UserService;
using HelloWorld.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        public IActionResult User()
        {
            var empty = new User();
            return View(empty);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registered(RegisterUser newuser)
        {
            var GetUser = _userService.Register(newuser);
            _userService.AddUser(GetUser);
            return RedirectToAction("Login");
        }
        
    }
}