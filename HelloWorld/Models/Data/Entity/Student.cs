using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models.Data.Entity
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(200)]
        public string  Name { get; set; }
        [Required,MaxLength(200)]
        public string  SurName { get; set; }
    }
}