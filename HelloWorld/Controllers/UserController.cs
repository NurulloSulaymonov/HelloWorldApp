using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models.Services;
using SchoolSystem.Models.ViewModel;

namespace SchoolSystem.Controllers
{
    public class UserController : Controller
    {
        private  IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService =  userService;
        }
        // GET
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        
        
        
        //register get and post
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        
        [HttpPost]
            public IActionResult Register(RegisterViewModel model)
            {
                //validity of model
                if (ModelState.IsValid == false) return View(model);

            var success = _userService.Register(model);
            if (success == false) return View(model);
          
            return RedirectToAction("Login");

        }
        
        
        //Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false) return View(model);

            var success = _userService.Login(model);
            if (success == false) return View(model);

            else return RedirectToAction("Success");

        }

        
        //success 
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult UserList()
        {
            var user = _userService.GetUsersList();
            return View(user);
        }
        
    }
}