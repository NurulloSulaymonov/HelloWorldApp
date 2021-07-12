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

        public IActionResult Success([FromQuery] int id)
        {
            return View();
        }



        //create get and post
        [HttpGet]
        public IActionResult Create()
        {
            var emptyStudent = new Student();
            return View(emptyStudent);
        }


        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid == false)
                return View(student);
            _studService.NewStudent(student);
            ViewBag.Message = "Success";
            return RedirectToAction("Index");
        }


        //for update get and post
        [HttpGet]
        public IActionResult Update([FromQuery] int id)
        {
            var student = _studService.GetStudentForUpdate(id);
            if (student == null) return RedirectToAction("index");
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student model)
        {
            if (ModelState.IsValid == false) return View(model);
            var update = _studService.UpdateStudent(model);
            return RedirectToAction("Index");
        }

        //for delete 
        public IActionResult Delete([FromQuery] int id)
        {

            _studService.Delete(id);
            return RedirectToAction("index", "Student");
        }

    }
}