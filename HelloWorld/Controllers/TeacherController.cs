using HelloWorld.Models.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace HelloWorld.Controllers
{
    public class TeacherController:Controller
    {
        private readonly TeacherService _teacherService;
        public TeacherController()
        {
            _teacherService = new TeacherService();
        }


        public IActionResult Index()
        {
            var data = _teacherService.GetTechers();
            return View(data);
        }
        
        public string Test()
        {
            var data = _teacherService.GetSimpeInfo();
            return data;
        }
    }
}