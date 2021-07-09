using FirstProject.Models.ModelView;
using FirstProject.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class TeachersController : Controller
    {
        private readonly TeacherService _teachersService;

        public TeachersController()
        {
            _teachersService = new TeacherService();
        }

        public IActionResult TeacherList()
        {
            var teachers = _teachersService.GetListOfTeacher();
            return View(teachers);
        }
       

        [HttpGet]
        public IActionResult TeacherCreate()
        {
            
            return View(new TeacherModel());
        }
        
        [HttpPost]
        public IActionResult TeacherCreate(TeacherModel teacherModel)
        {
            if (ModelState.IsValid == false) return View(teacherModel);
            _teachersService.CreateNewTeacher(teacherModel);
            return RedirectToAction("TeacherList");
        }
    }
}