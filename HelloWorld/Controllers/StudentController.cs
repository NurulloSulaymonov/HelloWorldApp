using HelloWorld.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudService _studService;
        private int cnt;
        public StudentController() //constructor
        {
            _studService = new StudService();
        }
        public IActionResult Index()
        {
            var listofStudents = _studService.GetListOfStud();
            return View(listofStudents);
        }

        public IActionResult list()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var emptyStudent = new Stud();
            return View(emptyStudent);
        }

        [HttpPost]
        public IActionResult Add(Stud student)
        {
            if (ModelState.IsValid == false)
                return View(student);
            _studService.NewStudent(student);
            return RedirectToAction("Index");
        }


        //for update

        [HttpGet]
        public IActionResult Update([FromQuery] int id)
        {
            var student = _studService.GetStudentForUpdate(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Stud model)
        {
            if (ModelState.IsValid == false) return View(model);
            var update = _studService.UpdateStudent(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromQuery] int id)
        {
            _studService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}