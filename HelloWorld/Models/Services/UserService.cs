using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HelloWorld.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;

namespace HelloWorld.Models.UserService
{
    public class UserService : IUserService
    {
        private string _connectionString =
            "Host=localhost;Username=postgres;Port=5432;Password=microsoft;Database=myfirstdb";
        private int random;
        private IUserService _userServiceImplementation;
        private IUserService _userServiceImplementation1;

        public UserService()
        {
            var randNumber = new Random();
            random = randNumber.Next(1, 1000);
        }

        public int GetRandomNumber()
        {
            return random;
        }
        
        public bool Register(RegisterView model)
        {
            var user = new User()
            {
                Password = model.Password,
                Phone = model.Phone,
                UserName = model.UserName
            };
            try
            {
                var con = new NpgsqlConnection(_connectionString);
                con.Open();

                var query = $"INSERT INTO users" +
                            $"(password,phone,username) " +
                            $"values " +
                            $"('{user.Password}','{user.Phone}','{user.UserName}')";
                var cmd = new NpgsqlCommand(query, con);
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Inserted successfully");
                }

                con.Close();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        } 
        public bool Login(LoginView model)
        {
            try
            {
                var con = new NpgsqlConnection(_connectionString);
                con.Open();

                var query = $"select * from users us where us.username = '{model.UserName}' and us.password = '{model.Password}';";
        
                var cmd = new NpgsqlCommand(query, con);
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<User> GetUsersList()
        {

            var user = new List<User>();
            var con = new NpgsqlConnection(_connectionString);
            con.Open();

            var sql = "SELECT * from users";

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