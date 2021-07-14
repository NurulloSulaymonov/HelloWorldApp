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

        public List<User> GetUserList()
        {
            var jsonString = File.ReadAllText("users.json");
            var Spiska = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return Spiska;
        }
        public User Register(RegisterUser model)
        {
            var users = GetUserList();
            if (users.Any(x => x.Username == model.Username) == true) return null;
            var last = users.OrderBy(x => x.Id).Last().Id;

            var newUser = new User()
            {
                Id = last + 1,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Username = model.Username
            };
            users.Add(newUser);
            var text = JsonConvert.SerializeObject(users);
            System.IO.File.WriteAllText("users.json", text);
            return newUser;
        }

        public void AddUser(User user)
        {
            var users = GetUserList();
            users.Add(user);
            var text = JsonConvert.SerializeObject(users);
            System.IO.File.WriteAllText("users.json", text);
        }
    }
}