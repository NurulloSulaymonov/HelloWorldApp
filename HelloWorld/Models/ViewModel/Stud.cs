using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models.ViewModel
{
    public class Stud
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter Surname")]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Please enter your day of Birday")]
        public string BirthData { get; set; }
        
        [Required(ErrorMessage = "Please enter your Gmail")]
        public string Gmail { get; set; }
    }
}