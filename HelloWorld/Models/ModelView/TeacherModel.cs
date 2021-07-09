using System.ComponentModel.DataAnnotations;
using System;
namespace FirstProject.Models.ModelView
{
    public class TeacherModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Age must be an intager")] 
        public string PhoneNumber { get; set; }
    }
}