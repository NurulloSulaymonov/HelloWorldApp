using HelloWorld.Models.StudService;
using HelloWorld.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService;
        public UserController() //constructor
        {
            _userService = new UserService();
        }


        //login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {

        }



    }
}