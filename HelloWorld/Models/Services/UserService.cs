using System.Collections.Generic;
using System.IO;
using System.Linq;
using HelloWorld.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HelloWorld.Models.UserService
{
    public class UserService
    {
        public UserService()
        {

        }

        public List<User> GetUserList()
        {
            var jsonString = File.ReadAllText("users.json");
            var Spiska = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return Spiska;
        }
        public bool Register(RegisterView model)
        {
            var users = GetUserList();
            if (users.Any(x => x.UserName == model.UserName) == true) return false;

            var newUser = new User()
            {
                Password = model.Password,
                Phone = model.Phone,
                UserName = model.UserName
            };
            if (users.Count() == 0)
            {
                newUser.Id = 1;
            }
            else
            {
                var last = users.OrderBy(x => x.Id).Last().Id;
                newUser.Id = last + 1;
            }
            users.Add(newUser);
            var text = JsonConvert.SerializeObject(users);
            System.IO.File.WriteAllText("users.json", text);
            return true;
        }

        public bool Login(LoginView model)
        {
            var users = GetUserList();
            return (users.Any(x => x.UserName == model.UserName && x.Password == model.Password));
        }
    }
}