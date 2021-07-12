using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using HelloWorld.Models.ViewModel;
using Newtonsoft.Json;

namespace HelloWorld.Models.StudService
{
    public class UserService
    {
        public UserService()
        {

        }

        public List<User> GetUserList()
        {
            var jsonString = File.ReadAllText("users.json");
            var usersList = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return usersList;
        }

        //for registering
        public User Register(RegisterUser model)
        {
            var users = GetUserList();

            if (users.Any(x => x.Username == model.Username) == true) return null;

            //else
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

        public bool Login(Login model)
        {
            var users = GetUserList();

            if (users.Any(x => x.Username == model.Username && x.Password == model.Password)) return true;

            else return false;


        }

    }
}