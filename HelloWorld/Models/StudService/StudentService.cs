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
        public List<Student> GetListOfStud()
        {
            var jsonString = File.ReadAllText("student.json");
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonString);
            return studentList;
        }

        public Student NewStudent(Student newstudent)
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
                var lastStudent = everyone.OrderBy(x => x.Id).Last();
                newstudent.Id = lastStudent.Id + 1;
                everyone.Add(newstudent);
            }

            var text = JsonConvert.SerializeObject(everyone);
            System.IO.File.WriteAllText("student.json", text);
            return newstudent;
        }

        public Student GetStudentForUpdate(int id)
        {
            var students = GetListOfStud();
            return students.FirstOrDefault(x => x.Id == id);
        }

        public Student UpdateStudent(Student student)
        {
            var students = GetListOfStud();
            var findStudent = students.First(x => x.Id == student.Id);
            findStudent.Gmail = student.Gmail;
            findStudent.Name = student.Name;

            var text = JsonConvert.SerializeObject(students);
            File.WriteAllText("student.json", text);
            return student;
        }

        public bool Delete(int id)
        {

            var students = GetListOfStud();
            var student = students.FirstOrDefault(x => x.Id == id); // look for student
            if (student == null)
            {
                return false;
            }

            students.Remove(student);
            var text = JsonConvert.SerializeObject(students);
            File.WriteAllText("student.json", text);
            return true;

        }
    }
}