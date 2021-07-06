using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace HelloWorld.Models.ViewModel
{
    public class StudService
    {
        public StudService()
        {
            
        }
        public List<Stud> GetListOfStud()
        {
            var newlist = File.ReadAllText("student.json");
            var studeent = JsonConvert.DeserializeObject<List<Stud>>(newlist);
            return studeent;
        }

        public Stud NewStudent(Stud newstudent)
        {
            var everyone = GetListOfStud();
            var min = everyone.OrderBy(x => x.id).Last();
            newstudent.id = min.id + 1 ;
            everyone.Add(newstudent);
            var text = JsonConvert.SerializeObject(everyone);
            System.IO.File.WriteAllText("student.json", text);
            return newstudent;
        }
    }
}