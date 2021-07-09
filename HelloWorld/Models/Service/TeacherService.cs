using FirstProject.Models.ModelView;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FirstProject.Models.Service
{
    public class TeacherService
    {
        public List<TeacherModel> GetListOfTeacher()
        {
            var jsonFile = File.ReadAllText("Teachers.json");
            var Teachers = JsonConvert.DeserializeObject<List<TeacherModel>>(jsonFile);
            return Teachers;
        }

        public TeacherModel CreateNewTeacher(TeacherModel teacherModel)
        {
            var AllTeachers = GetListOfTeacher();     
            AllTeachers.Add(teacherModel);
            var jsondata = JsonConvert.SerializeObject(AllTeachers);
            System.IO.File.WriteAllText("Teachers.json" , jsondata);
            return teacherModel;
        }
    }
}