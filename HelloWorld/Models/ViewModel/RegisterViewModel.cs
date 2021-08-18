using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password and confirm does not match")]
        public string ConfirmPassword { get; set; }
    }
}