using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class TeacherController : Controller
    {
        public TeacherController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}