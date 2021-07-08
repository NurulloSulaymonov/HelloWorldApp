using System.Collections.Generic;
using HelloWorld.Models.ViewModel;

namespace HelloWorld.Models.Services.TeacherService
{
    public class TeacherService
    {
        public string GetSimpeInfo()
        {
            return "Here simple logic";
        }
        
        public List<Teacher> GetTechers()
        {
            return new List<Teacher>()
            {
                new Teacher() {Gmail = "test", Id = 1, Name = "test"}
            };
        }
        
    }
}