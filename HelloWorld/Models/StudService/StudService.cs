using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var jsonString = File.ReadAllText("student.json");
            var studentList = JsonConvert.DeserializeObject<List<Stud>>(jsonString);
            return studentList;
        }

        public Stud NewStudent(Stud newstudent)
        {
            var everyone = GetListOfStud();
            if (everyone.Count == 0)
            {
                newstudent.Id = 1;
                everyone.Add(newstudent);
            }
            else // we get last record id 
            {
                var lastStudent = everyone.OrderBy(x => x.Id).Last();
                newstudent.Id = lastStudent.Id + 1;
                everyone.Add(newstudent);
            }

            var text = JsonConvert.SerializeObject(everyone);
            System.IO.File.WriteAllText("student.json", text);
            return newstudent;
        }

        public Stud GetStudentForUpdate(int id)
        {
            var students = GetListOfStud();
            return students.First(x => x.Id == id);
        }

        public Stud UpdateStudent(Stud student)
        {
            var students = GetListOfStud();
            var findStudent = students.First(x=>x.Id == student.Id);
            findStudent.Gmail = student.Gmail;
            findStudent.Name = student.Name;
            
            var text = JsonConvert.SerializeObject(students);
            File.WriteAllText("student.json", text);
            return student;
        }

        public void Delete(int id)
        {
            var list = GetListOfStud();
            var x = list.First(x => x.Id == id);
            list.Remove(x);
            var text = JsonConvert.SerializeObject(list);
            File.WriteAllText("student.json", text);
        }
    }
}