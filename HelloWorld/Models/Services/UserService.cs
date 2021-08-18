using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Npgsql;
using SchoolSystem.Models.ViewModel;

namespace SchoolSystem.Models.Services
{
    public class UserService : IUserService 
    {
        private static string _connectionString = "Host=localhost;Username=postgres;Password=hello;Database=MyFirstDB"; 
        public UserService()
        {
            
        }
        
        
        //register
        public bool Register(RegisterViewModel model)
        {
            var user = new User()
            {
                Password = model.Password,
                Phone = model.Phone,
                UserName = model.UserName
            };
            var con = new NpgsqlConnection(_connectionString);
            con.Open();

            var query = 
                $"INSERT INTO USERS(password, phone, username) " +
                $"VALUES (" +
                $"'{user.Password}', " +
                $"'{user.Phone}', " +
                $"'{user.UserName}'" +
                         $") ";
            var cmd = new NpgsqlCommand(query, con);
            var result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Inserted successfully");
            }
            con.Close();
            return true;
        }
        
        
        //login
        public bool Login(LoginViewModel model)
        {   

            var users = GetUsersList();

            var success = users.Any(x => x.UserName == model.UserName && x.Password == model.Password);
            return success;
        }
        
        //list

        public List<User> GetUsersList()
            {

                var user = new List<User>();
                var con = new NpgsqlConnection(_connectionString);
                con.Open();

                var sql = "SELECT * FROM users";

                var cmd = new NpgsqlCommand(sql, con);
                var reader = cmd.ExecuteReader(); /// baroi giriftani malumoto
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var newuser = new User()
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            UserName = reader.GetValue(3).ToString(),
                            Phone = reader.GetValue(2).ToString()
                        };
                        user.Add(newuser);
                    }
                }
                reader.Close();
                con.Close();

                return user;
            }
        }
    }