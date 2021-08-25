using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorld.Models.Data;
using HelloWorld.Models.Data.Entity;
using HelloWorld.Models.ViewModel;
using Npgsql;

namespace HelloWorld.Models.UserService
{
    public class UserService : IUserService
    {
        private readonly StudentContext _context;

        public UserService(StudentContext context)
        {
            _context = context;
        }


        public bool Register(RegisterView model)
        {
            var user = new User()
            {
                Password = model.Password,
                Phone = model.Phone,
                UserName = model.UserName
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            
            return true;
        }

        public bool Login(LoginView model)
        {
            var user = _context.Users.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
           
            return user != null;
        }

        public List<User> GetUsersList()
        {
            return  _context.Users.ToList();
            
        }
    }
}