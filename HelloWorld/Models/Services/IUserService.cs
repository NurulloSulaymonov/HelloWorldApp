using System.Collections.Generic;
using HelloWorld.Models.ViewModel;

namespace HelloWorld.Models.UserService
{
    public interface IUserService
    {
        bool Register(RegisterView model);
        bool Login(LoginView model);
        List<User> GetUsersList();
        public int GetRandomNumber();
    }
}