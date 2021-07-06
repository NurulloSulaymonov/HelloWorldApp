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
            //if collection is empty we just add a new student
            if (everyone.Count == 0)
            {
                newstudent.Id = 1;
                everyone.Add(newstudent);
            }
            else // we get last record id 
            {
                var min = everyone.OrderBy(x => x.Id).Last();
                newstudent.Id = 1;
                everyone.Add(newstudent);
            }

            var text = JsonConvert.SerializeObject(everyone);
            System.IO.File.WriteAllText("student.json", text);
            return newstudent;
        }
    }
}