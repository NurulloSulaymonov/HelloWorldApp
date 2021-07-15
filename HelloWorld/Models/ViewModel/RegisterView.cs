using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models.ViewModel
{
    public class RegisterView
    {
        public string UserName { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password doen't match")]
        public string ConfirmPassword { get; set; }

    }
}