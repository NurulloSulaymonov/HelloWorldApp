using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class StudentController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list()
        {
            return View();
        }

        public IActionResult add()
        {
            return View();
        }
    }
}