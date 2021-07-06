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

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Stud());
        }

        [HttpPost]
        public IActionResult Add(Stud student)
        {
            if (ModelState.IsValid == false)
                return View(student);
            var adding = _studService.NewStudent(student);
            return RedirectToAction("list");
        }
    }
}