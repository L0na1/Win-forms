using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public User() { }

        public User(string login, string password, string firstName,
                    string lastName, string phone, string email)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }
    }
}

