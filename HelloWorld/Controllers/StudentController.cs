using HelloWorld.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class StudentController : Controller
    {
        // GET
        private readonly StudService _studService;

        public StudentController()
        {
            _studService = new StudService();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list()
        {
            return View();
        }

        public IActionResult add(Stud student)
        {
            if (ModelState.IsValid == false)
                return View(student);
            var adding = _studService.NewStudent(student);
            return RedirectToAction("list");
        }
    }
}