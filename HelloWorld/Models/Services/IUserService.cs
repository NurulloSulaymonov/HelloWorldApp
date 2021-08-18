using System.Collections.Generic;
using SchoolSystem.Models.ViewModel;

namespace SchoolSystem.Models.Services
{
    public interface IUserService
    {
         bool Register(RegisterViewModel model); 
         bool Login(LoginViewModel model);

         List<User> GetUsersList(); 
    }
}