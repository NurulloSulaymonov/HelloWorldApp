using System.Security.AccessControl;
namespace HelloWorld.Models.ViewModel
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}